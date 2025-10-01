using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.model;

public partial class movieGenre
{
    [ForeignKey(nameof(Genre))]
    [Column(TypeName = "varchar(100)")]
    public string genereId { get; set; }
    [ForeignKey(nameof(movieInformation))]
    [Column(TypeName = "varchar(100)")]
    public string movieId { get; set; }
    
    public Genre Genre { get; set; }
    
    public movieInformation movieInformation { get; set; }
}

[PrimaryKey(nameof(movieId) , nameof(genereId))]
public partial class movieGenre
{
    
}