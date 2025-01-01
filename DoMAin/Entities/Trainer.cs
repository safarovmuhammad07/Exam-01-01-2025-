using System.ComponentModel.DataAnnotations;
using DoMAin.Enums;

namespace DoMAin.Entities;

public class Trainer
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string FirstName { get; set; }
    [Required, MaxLength(50)]
    public string LastName { get; set; }
    [Phone, Required]
    public string Phone { get; set; }
    public int Year { get; set; }
    public TrainerStatus Status  { get; set; }
    [MaxLength(100)]
    public string Specialization { get; set; }
    
    public List<WorkoutSession> WorkoutSessions { get; set; }
}