using LeaveApplication.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace LeaveApplication.Migrations
{
    public class LeaveApplicationContext: DbContext
    {
        public LeaveApplicationContext(DbContextOptions<LeaveApplicationContext> options) : base(options)
        {
        }
       
        public DbSet<Employee> Employeess { get; set; }
        public DbSet<Leave> Leavess { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employeess");
            modelBuilder.Entity<Leave>().ToTable("Leavess");
        }
    }
}
