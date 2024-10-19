using System.ComponentModel.DataAnnotations;

namespace IdentityFromScratch.Models;

public class OneTimePasscode
{
    public string OTPExpiry { get; set; }
    public string PhoneNumber { get; set; }
    
    [Required(ErrorMessage = "Missing Digit 1, ")]
    public string otp1 { get; set; }
    
    [Required(ErrorMessage = "Missing Digit 2, ")]
    public string otp2 { get; set; }
    
    [Required(ErrorMessage = "Missing Digit 3, ")]
    public string otp3 { get; set; }
    
    [Required(ErrorMessage = "Missing Digit 4, ")]
    public string otp4 { get; set; }
    
    [Required(ErrorMessage = "Missing Digit 5, ")]
    public string otp5 { get; set; }
    
    [Required(ErrorMessage = "Missing Digit 6")]
    public string otp6 { get; set; }
}