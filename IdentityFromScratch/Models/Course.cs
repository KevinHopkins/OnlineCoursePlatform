namespace IdentityFromScratch.Models;

public class Course
{
    public Course()
    {
        Enrolements = new List<Enrolment>();
    }
    
    public int Id { get; set; }

    public string Name  { get; set; }

    public string Description { get; set; }

    public decimal TotalPrice { get; set; }
    
    public decimal NetPrice { get; set; }
    
    public decimal VAT { get; set; }
    
    public List<Enrolment> Enrolements { get; set; }
}