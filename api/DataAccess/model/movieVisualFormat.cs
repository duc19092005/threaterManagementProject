using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.model;

public partial class movieVisualFormat
{
    [ForeignKey(nameof(movieInformation))]
    [Column(TypeName = "varchar(100)")]
    public string movieId { get; set; } 
    
    [ForeignKey(nameof(visualFormat))]
    [Column(TypeName = "varchar(100)")]
    public string visualFormatId { get; set; }
    public movieInformation movieInformation { get; set; } = null!;
    
    public visualFormat visualFormat { get; set; } = null!;
}

[PrimaryKey(nameof(movieId) , nameof(visualFormatId))]
public partial class movieVisualFormat
{
    
}
