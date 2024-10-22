using System.Diagnostics;
using System.Text.Encodings.Web;
using IdentityFromScratch.Models;
using IdentityFromScratch.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace IdentityFromScratch.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<Member> _userManager;
    private readonly SignInManager<Member> _signInManager;
    private readonly IEmailSender _emailSender;
    private readonly ITwilioVerifyService _twilioVerifyService;

    public AccountController(UserManager<Member> userManager, 
        SignInManager<Member> signInManager, 
        IEmailSender emailSender,
        ITwilioVerifyService twilioVerifyService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _emailSender = emailSender;
        _twilioVerifyService = twilioVerifyService;
    }
    
    [HttpGet]
    public IActionResult Register()
    {
        var registerViewModel = new RegisterViewModel();
        return View(registerViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
    {
        if (ModelState.IsValid)
        {
            var phoneNumberWithDiallingCode = string.Empty;
            var selectedCountryCode = registerViewModel.SelectedCountryCode;

            // Do something with the selected country code
            if (selectedCountryCode != null)
            {
                phoneNumberWithDiallingCode = ParseFullPhoneNumber(selectedCountryCode, registerViewModel.PhoneNumber);
            }
            else
            {
                ModelState.AddModelError(string.Empty, $"You must select a dialing code.");
                return View(registerViewModel);
            }
            
            // TODO Fetch Member by Email to find EnrolmentId
            var newMember = new Member()
            {
                Email = registerViewModel.Email,
                EnrolmentId = 1,
                UserName = registerViewModel.Email,
                PhoneNumber = phoneNumberWithDiallingCode,
                TwoFactorEnabled = true
            };
            
            var result = await _userManager.CreateAsync(newMember, registerViewModel.Password);
            
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(newMember, "Member");
                //await _userManager.AddToRoleAsync(newMember, "Admin");
                
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(newMember);
                var confirmationLink = Url.Action(nameof(ConfirmEmail), "Account",
                    new { userId = newMember.Id, token }, Request.Scheme);
                
                await _emailSender.SendEmailAsync(registerViewModel.Email, "Confirm your email",
                    $"Please confirm your email by <a href='{confirmationLink}'>clicking here</a>.");
                
                var isVerificationSent = await _twilioVerifyService.SendVerificationCodeAsync(newMember.PhoneNumber);
                if (isVerificationSent == "sent" ||  isVerificationSent == "pending")
                {
                    return RedirectToAction("VerifyPhoneAndEmail", new {phoneNumber = newMember.PhoneNumber, email = newMember.Email});                    
                }
                else
                {
                    ModelState.AddModelError(string.Empty, $"Error:  {isVerificationSent}");
                    return View(registerViewModel);
                }
               
                

            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
        
        return View(registerViewModel);
    }
    

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
        if (ModelState.IsValid)
        {
            var member =  await _userManager.FindByEmailAsync(loginViewModel.Username);
            
            if (member != null && !await _userManager.IsPhoneNumberConfirmedAsync(member))
            {
                ModelState.AddModelError(string.Empty, "You must verify your phone number before logging in.");
                return View(loginViewModel);
            }
            
            if (member != null && !await _userManager.IsEmailConfirmedAsync(member))
            {
                ModelState.AddModelError(string.Empty, "You must confirm your email before logging in.");
                return View(loginViewModel);
            }
            
            var result = await _signInManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, loginViewModel.RememberMe, true);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (result.RequiresTwoFactor)
            {
                // TODO Send Code
                // TODO Redirect to VerifyTwoFactor
                var isVerificationSent = await _twilioVerifyService.SendVerificationCodeAsync(member.PhoneNumber);
                if (isVerificationSent == "sent" ||  isVerificationSent == "pending")
                {
                    return RedirectToAction("VerifyTwoFactor", new {phoneNumber = member.PhoneNumber, email = member.Email});                    
                }
            }
            else if (result.IsLockedOut)
            {
                ModelState.AddModelError(string.Empty, "Too many login attempts. Your Account is locked out. Please try again later.");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt");
            }
        }

        return View(loginViewModel);

    }
    
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> ConfirmEmail(string userId, string token)
    {
        if (userId == null || token == null)
        {
            return RedirectToAction("Index", "Home");
        }
        
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound();
        }

        var result = await _userManager.ConfirmEmailAsync(user, token);
        if (result.Succeeded)
        {
            return View("ConfirmEmailSuccess");
        }

        return View("Error");

    }

    [HttpGet]
    public async Task<IActionResult> VerifyPhoneAndEmail(string phoneNumber)
    {
        var otpViewModel = new OneTimePasscode();
        
        otpViewModel.PhoneNumber = phoneNumber;
        otpViewModel.OTPExpiry = DateTime.UtcNow.AddMinutes(10).ToUniversalTime().ToString("o");;
        
        return View(otpViewModel);
    }
    
    [HttpPost]
    public async Task<IActionResult> VerifyPhoneAndEmail(string OTPExpiryTime, string phoneNumber, string email, string otp1, string otp2, string otp3, string otp4, string otp5, string otp6)
    {
        if (ModelState.IsValid)
        {
            var expiryDateTime = DateTime.Parse(OTPExpiryTime, null, System.Globalization.DateTimeStyles.RoundtripKind);

            if(DateTime.UtcNow >= expiryDateTime)
            {
                var oneTimePasscode = new OneTimePasscode()
                {
                    PhoneNumber = phoneNumber,
                    OTPExpiry = DateTime.UtcNow.AddDays(-1).ToUniversalTime().ToString("o")
                };
                ModelState.AddModelError(string.Empty, "Verification code has expired.  Please click on Resend to get another code.");
                return View(oneTimePasscode);
            }
            
            var isVerified = await _twilioVerifyService.VerifyCodeAsync(phoneNumber, $"{otp1}{otp2}{otp3}{otp4}{otp5}{otp6}");

            if (isVerified)
            {
                var user = await _userManager.FindByEmailAsync(email);
                user.PhoneNumberConfirmed = true;
                await _userManager.UpdateAsync(user);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid verification code.");
            }
            
        }
        

        return View();
    }
    
    
    [HttpGet]
    public IActionResult ForgotPassword()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
            // Don't reveal that the user does not exist
            return RedirectToAction("ForgotPasswordConfirmation");
        }

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var callbackUrl = Url.Action("ResetPassword", "Account", new { token, email = model.Email }, Request.Scheme);

        await _emailSender.SendEmailAsync(model.Email, "Reset Password",
            $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

        return RedirectToAction("ForgotPasswordConfirmation");
    }

    [HttpGet]
    public IActionResult ResetPassword(string token, string email)
    {
        if (token == null || email == null)
        {
            return RedirectToAction("Index", "Home");
        }
        var model = new ResetPasswordViewModel { Token = token, Email = email };
        return View(model);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
            // Don't reveal that the user does not exist
            return RedirectToAction("ResetPasswordConfirmation");
        }

        var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
        if (result.Succeeded)
        {
            return RedirectToAction("ResetPasswordConfirmation");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }
        return View();
    }

    [HttpGet]
    public IActionResult ForgotPasswordConfirmation()
    {
        return View();
    }

    [HttpGet]
    public IActionResult ResetPasswordConfirmation()
    {
        return View();
    }

    [HttpPost]
    public async Task<JsonResult> Resend(string phoneNumber)
    {
        var isSent = false;
        try
        {
            var isVerificationSent = await _twilioVerifyService.SendVerificationCodeAsync($"+{phoneNumber}");

            if (isVerificationSent == "sent" || isVerificationSent == "pending")
            {
                isSent = true;
            }
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
        }

        return new JsonResult(new { success = isSent });
    }

   [HttpGet]
    public IActionResult VerifyTwoFactor(string phoneNumber, string email)
    {
        var otpViewModel = new OneTimePasscode();

        otpViewModel.PhoneNumber = phoneNumber;
        otpViewModel.Email = email;
        otpViewModel.OTPExpiry = DateTime.UtcNow.AddMinutes(10).ToUniversalTime().ToString("o");;
        
        return View(otpViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> VerifyTwoFactor(string OTPExpiryTime, string phoneNumber, string email, string otp1, string otp2, string otp3, string otp4, string otp5, string otp6)
    {
        if (ModelState.IsValid)
        { 

           var expiryDateTime = DateTime.Parse(OTPExpiryTime, null, System.Globalization.DateTimeStyles.RoundtripKind);

           if(DateTime.UtcNow >= expiryDateTime)
           {
                var oneTimePasscode = new OneTimePasscode()
                {
                    PhoneNumber = phoneNumber,
                    OTPExpiry = DateTime.UtcNow.AddDays(-1).ToUniversalTime().ToString("o")
                };
                ModelState.AddModelError(string.Empty, "Verification code has expired.  Please click on Resend to get another code.");
                return View(oneTimePasscode);
           }
            
            var isVerified = await _twilioVerifyService.VerifyCodeAsync(phoneNumber, $"{otp1}{otp2}{otp3}{otp4}{otp5}{otp6}");

            if (isVerified)
            {
                var user = await _userManager.FindByEmailAsync(email);
                
                await _signInManager.SignInAsync(user, isPersistent: false);
                
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid verification code.");

            }
            
        }
        
        return View();
    }
    
    
    
    private string ParseFullPhoneNumber(string diallingCode, string phoneNumber)
    {
         return $"{diallingCode}{phoneNumber.Trim().TrimStart('0')}" ;
    }

    [HttpGet]
    public IActionResult VerifyTwoFactorByEmail(string phoneNumber, string email)
    {
        var otpViewModel = new OneTimePasscode();

        otpViewModel.PhoneNumber = phoneNumber;
        otpViewModel.Email = email;
        otpViewModel.OTPExpiry = DateTime.UtcNow.AddMinutes(10).ToUniversalTime().ToString("o");;
        
        
        // TODO User Own Implementation I think therefore next steps are DbContext
        // TODO Generate OTP - Can this be done in Twillio or use own implementation
        // TODO https://www.twilio.com/docs/verify/email#set-up-your-sendgrid-account
        // TODO Send email OTP
        // TODO Resend Email Functionality and rewire
        // TODO Reflect back to send by SMS therefore will need phone number too
        // TODO Will need to move send SMS to Verify 2FA by SMS Get Action 
        
        return View(otpViewModel);
    }
    
 
}