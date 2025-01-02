using DoMAin.DTOs;
using DoMAin.Entities;
using Infrastructure.ApiResponce;

namespace Infrastructure.Interfaces;

public interface ITrainerService
{
    Task<Responce<List<ReadTrainerDto>>> GetTrainersAsync( );
    Task<Responce<Trainer>> GetTrainerByIdAsync(int id);
    Task<Responce<CreateTrainerDto>> CreateTrainerAsync(CreateTrainerDto trainerr);
    Task<Responce<string>> UpdateTrainerAsync(UpdateTrainerDto trainer);
    Task<Responce<string>> DeleteTrainerAsync(int id);
}