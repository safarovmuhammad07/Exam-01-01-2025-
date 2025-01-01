using DoMAin.DTOs;
using DoMAin.Entities;
using Infrastructure.ApiResponce;

namespace Infrastructure.Interfaces;

public interface IWorkoutSessionSessionService
{
    Task<Responce<List<ReadWorkoutSesionBaseDto>>> GetWorkoutSessionsAsync();
    Task<Responce<CreateWorkoutSesionBaseDto>> CreateWorkoutSessionAsync(CreateWorkoutSesionBaseDto workoutSession);
    Task<Responce<UpdateWorkoutSesionBaseDto>> UpdateWorkoutSessionAsync(UpdateWorkoutSesionBaseDto workoutSession);
    Task<Responce<WorkoutSession>> DeleteWorkoutSessionAsync(int id);

}