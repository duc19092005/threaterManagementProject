namespace BussinessLogic.Result;

public class RegisterResult
{
    public string UserId { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string[] Roles { get; set; } = Array.Empty<string>();
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = string.Empty;

    public RegisterResult(string userId, string username, string fullName, string[] roles, bool isSuccess, string message)
    {
        UserId = userId;
        Username = username;
        FullName = fullName;
        Roles = roles;
        IsSuccess = isSuccess;
        Message = message;
    }

    public static RegisterResult Success(string userId, string username, string fullName, string[] roles)
    {
        return new RegisterResult(userId, username, fullName, roles, true, "Registration successful");
    }

    public static RegisterResult Failure(string message)
    {
        return new RegisterResult(string.Empty, string.Empty, string.Empty, Array.Empty<string>(), false, message);
    }
}
