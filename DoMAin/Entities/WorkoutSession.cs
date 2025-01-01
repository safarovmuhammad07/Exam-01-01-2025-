using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoMAin.Entities;

public class WorkoutSession
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Trainer")]
    public int TrainerId { get; set; }
    public  Trainer Trainer { get; set; }
    [ForeignKey("Client")]
    public int ClientId { get; set; }
    public  Client Client { get; set; }
    [ForeignKey("Workout")]
    public int WorkoutId { get; set; }
    public  Workout Workout { get; set; }
    [Timestamp]
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