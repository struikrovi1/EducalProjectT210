using Microsoft.EntityFrameworkCore;

namespace EducalProjectT210.Models
{
    public class CourseDBContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Course{ get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<Section1> Section1s { get; set; }

        public CourseDBContext(DbContextOptions opt):base(opt)
        {

        }

        
    }
}
