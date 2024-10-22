namespace IdentityFromScratch.Models;

public class Lessons
{
    public int Id { get; set; }
    
    public int CourseId { get; set; }
    
    public string Name  { get; set; }
    
    public string Header { get; set; }

    public string Description { get; set; }
    
    public Course Course { get; set; }
}