using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Enums;

namespace DataAccess.model;

public class seatsModel
{
    [Key]
    [Column(TypeName = "varchar(100)")]
    public string seatsId { get; set; } = null!;
    
    [Required]
    public string seatsNumber { get; set; } = null!;
    
    [ForeignKey(nameof(cinemaRoomModel))]
    [Required]
    [Column(TypeName = "varchar(100)")]
    public string cinemaRommId { get; set; } = null!;
    
    public locationStatusEnum seatsStatus { get; set; }
    
    public cinemaRoomModel cinemaRoomModel { get; set; } = null!;
}