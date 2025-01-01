using System.Net;
using DoMAin.DTOs;
using DoMAin.Entities;
using Infrastructure.ApiResponce;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class WorkoutSessionService(Context context):IWorkoutSessionSessionService
{
    public async Task<Responce<List<ReadWorkoutSesionBaseDto>>> GetWorkoutSessionsAsync()
    {
        var courses = context.WorkoutSessions
            .Include(c=>c.Workout)
            .AsEnumerable();
        
        var dto = courses.Select(c => new ReadWorkoutSesionBaseDto()
        {
            SessionDate = c.SessionDate,
            WorkoutId = c.Workout.Id,
            StartTime = c.StartTime,
            EndTime = c.EndTime,
            MaxCapacity = c.MaxCapacity,
            CurrentParticipant = c.CurrentParticipant,
            Comment = c.Comment,
            CreatedAt = c.CreatedAt,
            TrainerId = c.TrainerId,
            Client = c.Client,
            ClientId = c.ClientId,
            Workout = c.Workout
        }).ToList();

        return new Responce<List<ReadWorkoutSesionBaseDto>>(dto);
    }

    

    public async Task<Responce<CreateWorkoutSesionBaseDto>> CreateWorkoutSessionAsync(CreateWorkoutSesionBaseDto workoutSession)
    {
        var course = new WorkoutSession()
        {
           SessionDate = workoutSession.SessionDate,
           StartTime = workoutSession.StartTime,
           EndTime = workoutSession.EndTime,
           MaxCapacity = workoutSession.MaxCapacity,
           CurrentParticipant = workoutSession.CurrentParticipant,
           Comment = workoutSession.Comment,
           CreatedAt = workoutSession.CreatedAt
        };
        await context.WorkoutSessions.AddAsync(course);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Responce<CreateWorkoutSesionBaseDto>(HttpStatusCode.InternalServerError, "WorkoutSession Internal Server Error")
            : new Responce<CreateWorkoutSesionBaseDto>(HttpStatusCode.Created, $"WorkoutSession Created Successfully");

    }

    public Task<Responce<UpdateWorkoutSesionBaseDto>> UpdateWorkoutSessionAsync(UpdateWorkoutSesionBaseDto workoutSession)
    {
        throw new NotImplementedException();
    }

    public Task<Responce<WorkoutSession>> DeleteWorkoutSessionAsync(int id)
    {
        throw new NotImplementedException();
    }
}