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
        var res = await context.WorkoutSessions.ToListAsync();
        var workoutSessions = res.Select(x=>new ReadWorkoutSesionBaseDto()
        {
            WorkoutId = x.WorkoutId,
            ClientId = x.ClientId,
            TrainerId = x.TrainerId,
            Comment = x.Comment,
            CreatedAt = x.CreatedAt,
            EndTime = x.EndTime,
            StartTime = x.StartTime,
            MaxCapacity = x.MaxCapacity,
            SessionDate = x.SessionDate
        }).ToList();
        if (workoutSessions.Count == null)
            return new Responce<List<ReadWorkoutSesionBaseDto>>(HttpStatusCode.NotFound,"Not Found");
        return new Responce<List<ReadWorkoutSesionBaseDto>>(workoutSessions);
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

    public async Task<Responce<WorkoutSession>> DeleteWorkoutSessionAsync(int id)
    {
        var workoutSession = await context.WorkoutSessions.FirstOrDefaultAsync(x => x.Id == id);
        if (workoutSession == null) return new Responce<WorkoutSession>(HttpStatusCode.InternalServerError,"Internal Server Error");
        context.WorkoutSessions.Remove(workoutSession);
        var res = await context.SaveChangesAsync();
        return res == 0 ? new Responce<WorkoutSession>(HttpStatusCode.NotFound, "Not Found") : new Responce<WorkoutSession>(HttpStatusCode.OK,"Deleted");
    }
}