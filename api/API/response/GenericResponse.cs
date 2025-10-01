using backend.Enums;
using backend.response.AuthResponse;

namespace backend.response;

public class GenericResponse<T>
{
    public GenericResponse(string message,
        T? data, string [] links)
    {
        this.message = message;
        this.data = data;
        this.links = links;
    }

    public GenericResponse(string message)
    {
        this.message = message;
    }
    public string message { get; set; }
    public T? data { get; set; }
    public string[] links { get; set; } = [];
    
    public static GenericResponse<T> LoginSuccessfully(T data , string []links)
    {
        return new GenericResponse<T>("Login successfully" , data , links);
    }

    public static GenericResponse<T> GenericResponseFunction(T data, string[] links)
    {
        return new GenericResponse<T>("Generic response" , data , links);
    }

    public static GenericResponse<T> LoginFailure(string message)
    {
        return new GenericResponse<T>(message);
    }

    public static GenericResponse<T> RegisterSuccessfully(T data, string[] links)
    {
        return new GenericResponse<T>("Register successfully" , data , links);
    }
}