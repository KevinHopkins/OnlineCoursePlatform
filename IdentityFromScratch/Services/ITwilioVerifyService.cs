namespace IdentityFromScratch.Services;

public interface ITwilioVerifyService
{
    Task<string> SendVerificationCodeAsync(string phoneNumber);
    Task<bool> VerifyCodeAsync(string phoneNumber, string code);
}