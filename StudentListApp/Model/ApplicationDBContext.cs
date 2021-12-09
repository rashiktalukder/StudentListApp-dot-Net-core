using Microsoft.EntityFrameworkCore;

namespace StudentListApp.Model
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions <ApplicationDBContext> options):base(options)
        {

        }
        public DbSet<Student> Student { get; set; }

    }
}
