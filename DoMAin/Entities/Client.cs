using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace DoMAin.Entities;

public class Client
{
    [Key]
    public int Id { get; set; }
    [Required,MaxLength(50)]
    public string FirstName { get; set; }
    [Required, MaxLength(50)]
    public string LastName { get; set; }
    [Phone, Required]
    public string Phone { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [Timestamp]
    public DateTime DoB { get; set; }

    public List<WorkoutSession> WorkoutSessions { get; set; }
    
}