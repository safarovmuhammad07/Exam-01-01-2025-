using System.Net;
using DoMAin.DTOs;
using DoMAin.Entities;
using Infrastructure.ApiResponce;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class WorkoutService(Context context): IWorkoutService
{
    public Task<Responce<List<ReadWorkoutBaseDTO>>> GetWorkoutsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Responce<Workout>> GetWorkoutByIdAsync(int id)
    {
        var course = await context.Workouts.FirstOrDefaultAsync(g => g.Id == id);
        return course == null
            ? new Responce<Workout>(HttpStatusCode.NotFound, "Course not found")
            : new Responce<Workout>(course);
    }

    public async Task<Responce<CreateWorkoutBaseDTO>> CreateWorkoutAsync(CreateWorkoutBaseDTO workout)
    {
        var dto = new Workout()
        {
            Name = workout.Name,
            Description = workout.Description,
            Duration = workout.Duration,
            MaxParticipants = workout.MaxParticipants,
            Difficulty = workout.Difficulty,
            IsActive = workout.IsActive,
        };
        await context.Workouts.AddAsync(dto);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Responce<CreateWorkoutBaseDTO>(HttpStatusCode.InternalServerError, "Workout Internal Server Error")
            : new Responce<CreateWorkoutBaseDTO>(HttpStatusCode.Created, $"Workout Created Successfully");

    }

    public Task<Responce<UddateWorkoutBaseDTO>> UpdateWorkoutAsync(UddateWorkoutBaseDTO workout)
    {
        throw new NotImplementedException();
    }

    public Task<Responce<Workout>> DeleteWorkoutAsync(int id)
    {
        throw new NotImplementedException();
    }
}