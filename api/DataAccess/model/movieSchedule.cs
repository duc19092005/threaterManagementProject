using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Enums;

namespace DataAccess.model;

public class movieSchedule
{
    [Key]
    [Column(TypeName = "varchar(100)")]
    public string movieScheduleId { get; set; } = "";

    [ForeignKey(nameof(cinemaRoomModel))]
    [Column(TypeName = "varchar(100)")]
    [Required]

    public string cinemaRoomId { get; set; } = "";

    [ForeignKey(nameof(movieInformation))]
    [Column(TypeName = "varchar(100)")]
    [Required]
    public string movieId { get; set; } = "";

    [ForeignKey(nameof(visualFormat))]
    [Column(TypeName = "varchar(100)")]
    public string visualFormatId { get; set; } = "";

    public dayOfWeekEnum dayOfWeek { get; set; }

    public hourScheduleEnum hourSchedule { get; set; }
    
    [Required]
    public DateTime ScheduleDate { get; set; }

    // Trạng thái của lịch chiếu
    [Required]
    public bool IsDelete { get; set; }

    public cinemaRoomModel cinemaRoomModel { get; set; } = null!;

    public movieInformation movieInformation { get; set; } = null!;

    public List<ticketOrderDetail> ticketOrderDetail { get; set; } = [];
    
    public visualFormat visualFormat { get; set; } = null!;
    
}