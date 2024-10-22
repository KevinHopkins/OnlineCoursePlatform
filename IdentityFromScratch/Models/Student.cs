namespace IdentityFromScratch.Models;

public class Student
{
    public int Id { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }

    public string OTP { get; set; }
    
    public DateTime OTPExpiryTime { get; set; }
    
    public List<Enrolment> Enrolements { get; set; }
}