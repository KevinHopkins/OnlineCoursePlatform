namespace IdentityFromScratch.Services;

using Twilio.Rest.Verify.V2.Service;

public class TwilioVerifyService : ITwilioVerifyService
{
    private readonly string _verifyServiceSid;

    public TwilioVerifyService(IConfiguration configuration)
    {
        _verifyServiceSid = configuration["Twilio:VerifyServiceSid"];
    }

    public async Task<string> SendVerificationCodeAsync(string phoneNumber)
    {
        var verification = await VerificationResource.CreateAsync(
            to: phoneNumber,
            channel: "sms",
            pathServiceSid: _verifyServiceSid
        );
        return verification.Status;
    }

    public async Task<bool> VerifyCodeAsync(string phoneNumber, string code)
    {
        var verificationCheck = await VerificationCheckResource.CreateAsync(
            to: phoneNumber,
            code: code,
            pathServiceSid: _verifyServiceSid
        );
        return verificationCheck.Status == "approved";
    }
}
