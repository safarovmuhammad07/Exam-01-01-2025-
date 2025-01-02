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
    public async Task<Responce<List<ReadWorkoutBaseDTO>>> GetWorkoutsAsync()
    {
        var res = await context.Workouts.ToListAsync();
        var clients = res.Select(x=>new ReadWorkoutBaseDTO()
        {
            Description=x.Description,
            Difficulty=x.Difficulty,
            Duration=x.Duration,
            MaxParticipants=x.MaxParticipants,
            Name=x.Name,
            IsActive=x.IsActive
        }).ToList();
        if (clients.Count == null)
            return new Responce<List<ReadWorkoutBaseDTO>>(HttpStatusCode.NotFound,"Not Found");
        return new Responce<List<ReadWorkoutBaseDTO>>(clients);

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

    public async Task<Responce<UddateWorkoutBaseDTO>> UpdateWorkoutAsync(UddateWorkoutBaseDTO request)
    {
        var res = await context.Workouts.FirstOrDefaultAsync(x => x.Id == request.id);
        if (res == null) return new Responce<UddateWorkoutBaseDTO>(HttpStatusCode.InternalServerError,"Internal Server Error");
        res.Description=request.Description;
        res.Difficulty=request.Difficulty;
        res.Duration=request.Duration;
        res.MaxParticipants=request.MaxParticipants;
        res.Name=request.Name;
        res.IsActive=request.IsActive;
            var res2 = await context.SaveChangesAsync();
        return res2 == 0 ? new Responce<UddateWorkoutBaseDTO>(HttpStatusCode.NotFound,"Not Found") : new Responce<UddateWorkoutBaseDTO>(HttpStatusCode.OK,"Updated");
    }

    public  async Task<Responce<Workout>> DeleteWorkoutAsync(int id)
    {
        var client = await context.Workouts.FirstOrDefaultAsync(x => x.Id == id);
        if (client == null) return new Responce<Workout>(HttpStatusCode.InternalServerError,"Internal Server Error");
        context.Workouts.Remove(client);
        var res = await context.SaveChangesAsync();
            return res == 0 ? new Responce<Workout>(HttpStatusCode.NotFound, "Not Found") : new Responce<Workout>(HttpStatusCode.OK,"Deleted");
    }
}