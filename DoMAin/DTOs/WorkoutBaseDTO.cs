using System.ComponentModel.DataAnnotations;
using DoMAin.Entities;
using DoMAin.Enums;

namespace DoMAin.DTOs;

public record WorkoutBaseDTO
{
    [Required,MaxLength(50)]
    public string Name { get; set; }
    [MaxLength(500)]
    public string Description { get; set; }
    public string Duration { get; set; }
    public int MaxParticipants { get; set; }
    public WorkoutDifficulty  Difficulty { get; set; }
    public bool IsActive { get; set; }
}

public record CreateWorkoutBaseDTO: WorkoutBaseDTO{}

public record UddateWorkoutBaseDTO : WorkoutBaseDTO
{
    public int id { get; set; }
}

public record ReadWorkoutBaseDTO : WorkoutBaseDTO
{
    public List<WorkoutSession> WorkoutSessions { get; set; }
}