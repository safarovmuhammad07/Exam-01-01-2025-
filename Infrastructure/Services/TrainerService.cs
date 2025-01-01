using System.Net;
using DoMAin.DTOs;
using DoMAin.Entities;
using Infrastructure.ApiResponce;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class TrainerService(Context context): ITrainerService
{
    public Task<Responce<List<ReadTrainerDto>>> GetTrainersAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Responce<Trainer>> GetTrainerByIdAsync(int id)
    {
        var course = await context.Trainers.FirstOrDefaultAsync(g => g.Id == id);
        return course == null
            ? new Responce<Trainer>(HttpStatusCode.NotFound, "Course not found")
            : new Responce<Trainer>(course);
    }

    public async Task<Responce<CreateTrainerDto>> CreateTrainerAsync(CreateTrainerDto trainerr)
    {
        var trainer = new Trainer()
        {
            FirstName = trainerr.FirstName,
            LastName = trainerr.LastName,
            Phone = trainerr.Phone,
            Year = trainerr.Year,
            Status = trainerr.Status,
            Specialization = trainerr.Specialization
        };
        await context.Trainers.AddAsync(trainer);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Responce<CreateTrainerDto>(HttpStatusCode.InternalServerError, "WorkoutSession Internal Server Error")
            : new Responce<CreateTrainerDto>(HttpStatusCode.Created, $"WorkoutSession Created Successfully");

    }

    public Task<Responce<UpdateTrainerDto>> UpdateTrainerAsync(UpdateTrainerDto trainer)
    {
        throw new NotImplementedException();
    }

    public Task<Responce<Trainer>> DeleteTrainerAsync(int id)
    {
        throw new NotImplementedException();
    }
}