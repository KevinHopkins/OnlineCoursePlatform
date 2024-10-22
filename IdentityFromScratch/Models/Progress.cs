namespace IdentityFromScratch.Models;

public class Progress
{

    public int Id { get; set; }
    
    public int MemberId { get; set; }
    public int LessonId { get; set; }
    
    public bool IsCompleted { get; set; }
    
    public bool IsStarted { get; set; }
    
    public bool IsNext { get; set; }
    
    public Lessons Lesson { get; set; }
    
    public Student Student { get; set; }
}