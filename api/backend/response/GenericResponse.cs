using backend.Enums;
using JetBrains.Annotations;

namespace backend.response;

public class GenericResponse<T>
{
    public statusCodeEnum responseCode { get; set; }
    public string message { get; set; } = string.Empty;
    public T? data { get; set; }
}