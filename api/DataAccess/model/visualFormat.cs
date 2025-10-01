using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.model;

[Index(nameof(visualFormatName) , IsUnique = true)]
public class visualFormat
{
    [Key]
    [Column(TypeName = "varchar(100)")]
    public string visualFormatId { get; set; } = null!;
    
    [Column(TypeName = "char(20)")]
    public string visualFormatName { get; set; } = null!;
    
    [ForeignKey(nameof(priceForVisualFormat))]
    [Column(TypeName = "varchar(100)")]
    public string priceId { get; set; } = null!;
    
    public List<movieVisualFormat> movieVisualFormat = [];

    public List<cinemaRoomModel> cinemaRoomModel = [];
    
    public List<movieSchedule> movieSchedule = [];
    public priceForVisualFormat priceForVisualFormat { get; set; } = null!;
}