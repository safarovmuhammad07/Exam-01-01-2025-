using DoMAin.DTOs;
using DoMAin.Entities;
using Infrastructure.ApiResponce;

namespace Infrastructure.Interfaces;

public interface IWorkoutService
{
    Task<Responce<List<ReadWorkoutBaseDTO>>> GetWorkoutsAsync();
    Task<Responce<Workout>> GetWorkoutByIdAsync(int id);
    Task<Responce<CreateWorkoutBaseDTO>> CreateWorkoutAsync(CreateWorkoutBaseDTO workout);
    Task<Responce<UddateWorkoutBaseDTO>> UpdateWorkoutAsync(UddateWorkoutBaseDTO workout);
    Task<Responce<Workout>> DeleteWorkoutAsync(int id);

}