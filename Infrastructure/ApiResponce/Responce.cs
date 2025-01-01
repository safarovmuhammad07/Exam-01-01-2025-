using System.Net;

namespace Infrastructure.ApiResponce;

public class Responce<T>
{
    public Responce(T date)
    {
        Data = date;
        Message=string.Empty;
        StatusCode = 200;
    }

    public Responce(HttpStatusCode statusCode,string message)
    {
        Message = message;
        StatusCode = (int)statusCode;
        Data = default;
    }
    
    public T? Data { get; set; }
    public string Message { get; set; }
    public int StatusCode{ get; set; }
}