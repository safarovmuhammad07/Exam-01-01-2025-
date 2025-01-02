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

    public async Task<Responce<string>> CreateClientAsync(CreateClientBaseDTO client)
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
            ? new Responce<string>(HttpStatusCode.InternalServerError, "WorkoutSession Internal Server Error")
            : new Responce<string>(HttpStatusCode.Created, $"WorkoutSession Created Successfully");

    }

    public  async Task<Responce<string>> UpdateClientAsync(UpdateClientBaseDTO dto)
    {
        var x = await context.Clients.Include(v => v.WorkoutSessions).FirstOrDefaultAsync(c=>c.Id==dto.Id);
        if (x == null)
            return new Responce<string>(HttpStatusCode.NotFound , "Not Found");
        
        x.FirstName = dto.FirstName;
        x.LastName = dto.LastName;
        x.Phone = dto.Phone;
        x.Email = dto.Email;
        x.DoB = dto.DoB;
        var result = await context.SaveChangesAsync();
        return result == 0 
            ? new Responce<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Responce<string>(HttpStatusCode.Created, "Client Updated");

    }

    public async Task<Responce<Client>> DeleteClientAsync(int id)
    {
        var x = await context.Clients.Include(v => v.WorkoutSessions).FirstOrDefaultAsync(c=>c.Id==id);
        if (x == null)
            return new Responce<Client>(HttpStatusCode.NotFound , "Not Found");
        
        context.Clients.Remove(x);
        var result = await context.SaveChangesAsync();
        return result == 0 
            ? new Responce<Client>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Responce<Client>(HttpStatusCode.Created, "Client deleted");
    }
}