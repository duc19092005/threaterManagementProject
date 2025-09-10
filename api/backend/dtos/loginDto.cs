using System.ComponentModel.DataAnnotations;

namespace backend.dtos;

public class loginDto
{
    [Required(ErrorMessage = "Username is required")]
    public string userName { get; set; } 
    
    [Required(ErrorMessage = "Password is required")]
    public string password { get; set; } 
}