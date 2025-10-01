using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.model;

public class productModel
{
    [Key]
    [Column(TypeName="varchar(100)")]
    public string productId { get; set; } = null!;
    
    [Column(TypeName = "nvarchar(50)")]
    public string productName { get; set; } = null!;
    
    [Column(TypeName = "nvarchar(max)")]
    public string productDescription { get; set; } = null!;
    
    [Column(TypeName = "varchar(max)")]
    public string productImage { get; set; } = null!;
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal productPrice { get; set; }

    public List<cinemaProductModel> cinemaProductModel { get; set; } = [];
}