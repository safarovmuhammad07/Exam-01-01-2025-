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
            .HasMany(t => t.WorkoutSessions)
            .WithOne(w =>w.Trainer)
            .HasForeignKey(w=>w.TrainerId);
        
        modelBuilder.Entity<Client>()
            .HasMany(t => t.WorkoutSessions)
            .WithOne(w =>w.Client)
            .HasForeignKey(w=>w.ClientId);
        
        modelBuilder.Entity<Workout>()
            .HasMany(t => t.WorkoutSessions)
            .WithOne(w =>w.Workout)
            .HasForeignKey(w=>w.WorkoutId);

        
    }
}