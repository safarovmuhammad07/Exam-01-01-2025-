using DoMAin.DTOs;
using DoMAin.Entities;
using Infrastructure.ApiResponce;

namespace Infrastructure.Interfaces;

public interface IClientService
{
    Task<Responce<List<ReadClientBaseDTO>>> GetClientsAsync();
    Task<Responce<Client>> GetClientByIdAsync(int id);
    Task<Responce<CreateClientBaseDTO>> CreateClientAsync(CreateClientBaseDTO client);
    Task<Responce<UpdateClientBaseDTO>> UpdateClientAsync(UpdateClientBaseDTO client);
    Task<Responce<Client>> DeleteClientAsync(int id);

}