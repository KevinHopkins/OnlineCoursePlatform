namespace IdentityFromScratch.Models;

public class Objectives
{
    public int Id { get; set; }
    
    public int LessonId { get; set; }
    
    public string Name { get; set; }
    
    public string Objective  { get; set; }
    
    public Lessons Lesson { get; set; }
}