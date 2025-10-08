namespace BussinessLogic.Result;

public class AuthenticatedResult
{
    public string userId { get; private set; }
    public string username { get; private set; }
    public string [] roles { get; private set; }

    public AuthenticatedResult()
    {
        
    }
    public AuthenticatedResult(string userId, string username, string?[] roles)
    {
        this.userId = userId;
        this.username = username;
        this.roles = roles;
    }
}