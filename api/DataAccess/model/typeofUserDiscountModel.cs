using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Enums;

namespace DataAccess.model;

public class typeofUserDiscountModel
{
    [Key]
    [Column(TypeName = "varchar(100)")]
    public string typeofUserDiscountId { get; set; } = null!;
    
    [Required]
    public typeofUserEnum typeOfUser {get; set;}
    
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal discountAmount { get; set; }
}