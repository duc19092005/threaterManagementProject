namespace BussinessLogic.customException;

public class AuthException : System.Exception
{
    public AuthException(string message) : base(message) { }
}