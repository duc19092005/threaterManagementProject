using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.model;

public class Genre
{
    [Key]
    [Column(TypeName = "varchar(100)")]
    public string movieGenreId { get; set; } = string.Empty;
    
    public string movieGenreName { get; set; } = string.Empty;

    public List<movieGenre> movieGenre { get; set; } = [];
}