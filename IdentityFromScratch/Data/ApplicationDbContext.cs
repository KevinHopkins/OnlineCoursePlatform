using IdentityFromScratch.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityFromScratch.Data;

public class ApplicationDbContext : IdentityDbContext<Member>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
        
    }
    
    public DbSet<Student> Sudents { get; set; }
    
    public DbSet<Enrolment> Enrolments { get; set; }
    
    public DbSet<Course> Courses { get; set; }
    
    public DbSet<Lessons> Lessons { get; set; }
    
    public DbSet<Objectives> Objectives { get; set; }
    
    public DbSet<Progress> Progress { get; set; }
    
}