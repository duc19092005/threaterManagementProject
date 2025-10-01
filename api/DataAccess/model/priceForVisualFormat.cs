using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.model;

public class priceForVisualFormat
{
    [Key]
    [Column(TypeName = "varchar(100)")]

    public string priceId { get; set; } = null!;
    
    [Column(TypeName = "varchar(100)")]

    public string visualFormatId { get; set; } = null!;

    [Column(TypeName = "decimal(18,2)")]
    [Required]
    public decimal priceDetail { get; set; }

    public List<movieVisualFormat> movieVisualFormat { get; set; }
        = [];
}