using Microsoft.AspNetCore.Identity;

namespace IdentityFromScratch.Models;

public class Member : IdentityUser
{
    public int EnrolmentId { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }

    public string OTP { get; set; }
    
    public DateTime OTPExpiryTime { get; set; }
    
    public List<Enrolment> Enrolements { get; set; }
}