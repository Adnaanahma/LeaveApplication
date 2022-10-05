using LeaveApplication.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace LeaveApplication.Migrations
{
    public class LeaveApplicationContext: DbContext
    {
        public LeaveApplicationContext(DbContextOptions<LeaveApplicationContext> options) : base(options)
        {
        }
       
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Leave> Leaves { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Leave>().ToTable("Leaves");
        }
    }
}
