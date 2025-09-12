namespace backend.response;

public class jwtClaimsResponse
{
    public string userId { get; set; } = string.Empty;
    
    public string userEmail { get;set; } = string.Empty;
    
    public string[] userRoles { get; set; } = [];

}