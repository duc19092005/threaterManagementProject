using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Enums;

namespace DataAccess.model;

public class Cinema
{
    [Key]
    [Column(TypeName = "varchar(100)")]
    public string cinemaId {get; set;} = null!;
    
    public string cinemaName {get; set;} = null!;
    
    public string cinemaAddress {get; set;} = null!;

    [Column(TypeName = "char(10)")]
    public string cinemaHotLineNumber { get; set; } = null!;
    
    public locationStatusEnum cinemaStatus { get; set; }

    public List<cinemaRoomModel> cinemaRoomModel { get; set; } = [];

    public List<staffModel> staffModel { get; set; } = [];

    public List<cinemaProductModel> cinemaProductModel { get; set; } = [];

}