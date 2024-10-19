using Microsoft.AspNetCore.Identity;

namespace IdentityFromScratch.Models;

public class Member : IdentityUser
{
    public int EnrolmentId { get; set; }
}