using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BussinessLogic.dtos;

public class registerDto
{
    [Required(ErrorMessage = "CCCD/CMND is required")]
    [Column(TypeName = "varchar(100)")]
    public string IdentityNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "Username is required")]
    [EmailAddress(ErrorMessage = "Username must be a valid email address")]
    public string username { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Password is required")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
    public string password { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Confirm password is required")]
    [Compare("password", ErrorMessage = "Password and confirm password do not match")]
    public string confirmPassword { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Full name is required")]
    [StringLength(100, ErrorMessage = "Full name cannot exceed 100 characters")]
    public string fullName { get; set; } = string.Empty;
    
    [RegularExpression("^0\\d{9}$\n" , ErrorMessage = "Phone Is Invalid")]
    public string? phoneNumber { get; set; }
    
    [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters")]
    public string? address { get; set; }
}