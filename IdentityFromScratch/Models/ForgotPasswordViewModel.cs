using System.ComponentModel.DataAnnotations;

namespace IdentityFromScratch.Models;

public class ForgotPasswordViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}