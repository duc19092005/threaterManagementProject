namespace BussinessLogic.Result;

public class RegisterResult
{
    public int statusCode { get; set; }
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = string.Empty;

    public RegisterResult(int statusCode, bool isSuccess, string message)
    {
        this.statusCode = statusCode;
        IsSuccess = isSuccess;
        Message = message;
    }

    public static RegisterResult Success(int statusCode, string message)
    {
        return new RegisterResult(statusCode , true, message);
    }

    public static RegisterResult Failure(int statusCode , string message)
    {
        return new RegisterResult(statusCode, false, message);
    }
}
