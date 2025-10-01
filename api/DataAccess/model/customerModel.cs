using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.model;

public class customerModel
{
    [Key]
    [Column(TypeName = "varchar(100)")]
    public string customerId { get; set; }
    
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string customerName { get; set; }
    
    [Column(TypeName = "char(10)")]
    [Required]
    public string customerPhoneNumber { get; set; }
    
    
    [Column(TypeName = "varchar(100)")]
    [Required]
    public string customerIdentityNumber { get; set; }
    
    [ForeignKey(nameof(userModel))]
    public string userId { get; set; }
    public userModel userModel { get; set; }
}