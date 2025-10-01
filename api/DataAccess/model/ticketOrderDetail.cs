using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.model;

public partial class ticketOrderDetail
{
    [Column(TypeName = "varchar(100)")]
    [ForeignKey(nameof(orderModel))]
    public string orderId { get; set; } = "";

    [Column(TypeName = "varchar(100)")]
    [ForeignKey(nameof(movieSchedule))]
    public string movieScheduleID { get; set; } = string.Empty;

    [Column(TypeName = "varchar(100)")]
    [ForeignKey(nameof(seatsModel))]
    public string seatId { get; set; } = "";
        
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal PriceEach { get; set; } = 0;

    public orderModel orderModel { get; set; } = null!;

    public seatsModel seatsModel { get; set; } = null!;

    public movieSchedule movieSchedule { get; set; } = null!;
}
[PrimaryKey(nameof(orderId) ,nameof(seatId))]
public partial class ticketOrderDetail
{
    
}
