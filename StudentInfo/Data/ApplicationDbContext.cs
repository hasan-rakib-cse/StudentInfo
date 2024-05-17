using Microsoft.EntityFrameworkCore;
using StudentInfo.Models;

namespace StudentInfo.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        { 
        }

        public DbSet<Student> Students { get; set; }
    }
}
