using DoMAin.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
    public DbSet<Trainer> Trainers { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<WorkoutSession> WorkoutSessions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Trainer>()
            .HasCheckConstraint("CK_Trainer_Experience", "\"Experience\" > 0 and \"Experience\" < 100")
            .HasMany(t => t.WorkoutSessions)
            .WithOne(w => w.Trainer)
            .HasForeignKey(w => w.TrainerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Client>()
            .HasCheckConstraint("CK_Client_DateOfBirth", "\"DateOfBirth\" >= CURRENT_DATE - INTERVAL '16 years'")
            .HasMany(t => t.WorkoutSessions)
            .WithOne(w => w.Client)
            .HasForeignKey(w => w.ClientId);

        modelBuilder.Entity<Workout>()
            .HasCheckConstraint("CK_Workout_MaxParticipants", "\"MaxParticipants\" > 0")
            .HasMany(t => t.WorkoutSessions)
            .WithOne(w => w.Workout)
            .HasForeignKey(w => w.WorkoutId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<WorkoutSession>()
            .HasCheckConstraint("CK_Workout_StartTime", "\"StartTime\" >= '07:00:00' and \"StartTime\" <= '23:00:00'")
            .HasCheckConstraint("CK_Workout_EndTime", "\"EndTime\" >= '07:00:00' and \"EndTime\" <= '23:00:00'");
    }
}