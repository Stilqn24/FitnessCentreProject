using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnesCentar.Data
{
    public class ApplicationDbContext : IdentityDbContext<Client>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ProgramTask> ProgramTasks { get; set; }
        public DbSet<FitnesInstructor> FitnesInstructors { get; set; }
        public DbSet<ProgramCategory> ProgramCategories { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ScheduleActivity> ScheduleActivities { get; set; }
    }
}
