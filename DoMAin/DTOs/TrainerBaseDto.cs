using System.ComponentModel.DataAnnotations;
using DoMAin.Entities;
using DoMAin.Enums;

namespace DoMAin.DTOs;

public record TrainerBaseDto
{
    public string FirstName { get; set; }
    [Required, MaxLength(50)]
    public string LastName { get; set; }
    [Phone, Required]
    public string Phone { get; set; }
    public int Year { get; set; }
    public TrainerStatus Status  { get; set; }
    [MaxLength(100)]
    public string Specialization { get; set; }

}

public record CreateTrainerDto : TrainerBaseDto { }

public record UpdateTrainerDto : TrainerBaseDto
{
    public int Id { get; set; }
}

public record ReadTrainerDto : TrainerBaseDto
{
    public int Id { get; set; }
    public List<Workout> Workouts { get; set; }
}
