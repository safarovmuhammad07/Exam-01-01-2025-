using System.Net;
using DoMAin.DTOs;
using DoMAin.Entities;
using Infrastructure.ApiResponce;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ClientService(Context context):IClientService
{
    public Task<Responce<List<ReadClientBaseDTO>>> GetClientsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Responce<Client>> GetClientByIdAsync(int id)
    {
        var course = await context.Clients.FirstOrDefaultAsync(g => g.Id == id);
        return course == null
            ? new Responce<Client>(HttpStatusCode.NotFound, "Course not found")
            : new Responce<Client>(course);
    }

    public async Task<Responce<CreateClientBaseDTO>> CreateClientAsync(CreateClientBaseDTO client)
    {
        var course = new Client()
        {
            FirstName = client.FirstName,
            LastName = client.LastName,
            Email = client.Email,
            Phone = client.Phone,
            DoB = client.DoB,
            
        };
        await context.Clients.AddAsync(course);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Responce<CreateClientBaseDTO>(HttpStatusCode.InternalServerError, "WorkoutSession Internal Server Error")
            : new Responce<CreateClientBaseDTO>(HttpStatusCode.Created, $"WorkoutSession Created Successfully");

    }

    public Task<Responce<UpdateClientBaseDTO>> UpdateClientAsync(UpdateClientBaseDTO client)
    {
        throw new NotImplementedException();
    }

    public Task<Responce<Client>> DeleteClientAsync(int id)
    {
        throw new NotImplementedException();
    }
}