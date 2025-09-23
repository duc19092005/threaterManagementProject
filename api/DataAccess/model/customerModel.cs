using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using backend.model;

namespace DataAccess.model;

public class customerModel : timerBaseModel
{
    [Key]
    public string customerId { get; set; }
    [Required]
    public string fullName { get; set; }
    [Required]
    public DateTime dateOfBirth { get; set; }
    [Required]
    public string phoneNumber { get; set; }
    [Required]
    public string identityNumber { get; set; }
    [Required]
    [ForeignKey("userModel")]
    public string userId {get; set;}
    
    public userModel userModel { get; set; }
}