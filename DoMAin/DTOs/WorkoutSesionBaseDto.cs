using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DoMAin.Entities;

namespace DoMAin.DTOs;

public record WorkoutSesionBaseDto
{
    public DateTime SessionDate  { get; set; }
    public DateTime StartTime  { get; set; }
    public DateTime EndTime { get; set; }
    public int MaxCapacity  { get; set; }
    public int CurrentParticipant{ get; set; }
    [MaxLength(200)]
    public string Comment  { get; set; }
    [Timestamp]
    public DateTime CreatedAt { get; set; }
    

}

public record CreateWorkoutSesionBaseDto : WorkoutSesionBaseDto{}

public record UpdateWorkoutSesionBaseDto : WorkoutSesionBaseDto
{
    public int Id { get; set; }
}

public record ReadWorkoutSesionBaseDto : WorkoutSesionBaseDto
{
    public int TrainerId { get; set; }
    public  Trainer Trainer { get; set; }
    [ForeignKey("Client")]
    public int ClientId { get; set; }
    public  Client Client { get; set; }
    [ForeignKey("Workout")]
    public int WorkoutId { get; set; }
    public  Workout Workout { get; set; }
}