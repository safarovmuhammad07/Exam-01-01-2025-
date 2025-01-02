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
     public async Task<Responce<List<ReadTrainerDto>>> GetTrainersAsync()
    {
       
        var res = await context.Trainers.ToListAsync();
        var trainers = res.Select(x=>new ReadTrainerDto()
        {
            LastName = x.LastName,
            Specialization = x.Specialization,
            Status = x.Status,
            FirstName = x.FirstName,
            Phone = x.Phone
        }).ToList();
        if (trainers.Count == null)
            return new Responce<List<ReadTrainerDto>>(HttpStatusCode.NotFound,"Not Found");
        return new Responce<List<ReadTrainerDto>>(trainers);
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

    public async Task<Responce<string>> UpdateTrainerAsync(UpdateTrainerDto request)
    {
        var res = await context.Trainers.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (res == null) return new Responce<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
        res.LastName = request.LastName;
        res.Specialization = request.Specialization;
        res.Status = request.Status;
        res.FirstName = request.FirstName;
        res.Phone= request.Phone;
        var res2 = await context.SaveChangesAsync();
        if (res2 == 0) return new Responce<string>(HttpStatusCode.NotFound,"Not Found");
        return new Responce<string>("Updated");
    }

    public async Task<Responce<string>> DeleteTrainerAsync(int id)
    {
        var trainer = await context.Trainers.FirstOrDefaultAsync(x => x.Id == id);
        if (trainer == null) return new Responce<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
        context.Trainers.Remove(trainer);
        var res = await context.SaveChangesAsync();
        if (res == 0) return new Responce<string>(HttpStatusCode.NotFound, "Not Found");
        else return new Responce<string>("Deleted");
    }
}