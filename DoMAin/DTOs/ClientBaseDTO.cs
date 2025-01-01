using System.ComponentModel.DataAnnotations;
using DoMAin.Entities;

namespace DoMAin.DTOs;

public record ClientBaseDTO
{
    public string FirstName { get; set; }
    [Required, MaxLength(50)]
    public string LastName { get; set; }
    [Phone, Required]
    public string Phone { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [Timestamp]
    public DateTime DoB { get; set; }
}

public record CreateClientBaseDTO : ClientBaseDTO { }

public record UpdateClientBaseDTO : ClientBaseDTO
{
    public int Id { get; set; }
}

public record ReadClientBaseDTO : ClientBaseDTO
{
    public List<WorkoutSession> WorkoutSessions { get; set; }
}