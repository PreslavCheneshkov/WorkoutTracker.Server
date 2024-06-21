using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Server.Data.Entities.Exercise;
using WorkoutTracker.Server.Data.Entities.Training;
using WorkoutTracker.Server.Data.Entities.User;

namespace WorkoutTracker.Server.Data
{
    public class WorkoutTrackerDbContext : IdentityDbContext<WorkoutTrackerUser>
    {
        public WorkoutTrackerDbContext() : base()
        {
        }

        public WorkoutTrackerDbContext(DbContextOptions<WorkoutTrackerDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<TrainingSession> TrainingSessions { get; set; }

        public DbSet<Exercise> Exercises { get; set; }

        public DbSet<ExerciseName> ExerciseNames { get; set; }

        public DbSet<ExerciseParameter> ExerciseParameters { get; set; }

        public DbSet<ExerciseParameterName> ExerciseParameterNames { get; set; }

        public DbSet<PersonalStatsMeasurement> PersonalStats { get; set; }
    }
}
