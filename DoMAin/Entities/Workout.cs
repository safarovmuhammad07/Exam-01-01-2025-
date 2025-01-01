using System.ComponentModel.DataAnnotations;
using DoMAin.Enums;

namespace DoMAin.Entities;

public class Workout
{
    [Key]
    public int Id { get; set; }
    [Required,MaxLength(50)]
    public string Name { get; set; }
    [MaxLength(500)]
    public string Description { get; set; }
    public string Duration { get; set; }
    public int MaxParticipants { get; set; }
    public WorkoutDifficulty  Difficulty { get; set; }
    public bool IsActive { get; set; }
    public List<WorkoutSession> WorkoutSessions { get; set; }
    
    
}