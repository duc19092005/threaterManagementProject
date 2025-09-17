using System.ComponentModel.DataAnnotations;

namespace BussinessLogic.dtos;

public class loginDto
{
    [Required(ErrorMessage = "Username is required")]
    public string username { get; set; } 
    
    [Required(ErrorMessage = "Password is required")]
    public string password { get; set; } 
}