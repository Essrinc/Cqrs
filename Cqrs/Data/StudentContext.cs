using Microsoft.EntityFrameworkCore;

namespace Cqrs.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new Student[]
            {
                new Student() {Id = 1, Name = "Esra", Surname = "Özcan", Age = 23},
                new Student() {Id = 2, Name = "Ysuf", Surname = "Özcan", Age = 18},
                new Student() {Id = 3, Name = "Serap", Surname = "Özcan", Age = 47},
                new Student() {Id = 4, Name = "Ayhan", Surname = "Özcan", Age = 53}
            });
        }
        public DbSet<Student> Students { get; set; }
    }
}
