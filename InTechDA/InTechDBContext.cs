using InTechDA.Entities;
using Microsoft.EntityFrameworkCore;

namespace InTechDA
{
    public class InTechDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public InTechDBContext(DbContextOptions<InTechDBContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships (if needed)
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentID)
                .OnDelete(DeleteBehavior.Cascade); // Optional, based on your use case


            modelBuilder.Entity<Department>().HasData(
          new Department { ID = 1, Name = "HR" },
          new Department { ID = 2, Name = "IT" },
          new Department { ID = 3, Name = "Finance" }
      );
        }
    }
}
