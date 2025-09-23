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
    [Column(TypeName = "nvarchar(100)")]
    public string fullName { get; set; }
    [Required]
    public DateTime dateOfBirth { get; set; }
    [Required]
    [Column(TypeName = "char(10)")]
    public string phoneNumber { get; set; }
    [Required]
    [Column(TypeName = "varchar(150)")]
    public string identityNumber { get; set; }
    [Required]
    [ForeignKey("userModel")]
    public string userId {get; set;}
    
    public userModel userModel { get; set; }
}