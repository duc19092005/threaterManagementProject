using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace DataAccess.model;

public class orderModel
{
    [Key]
    [Column(TypeName = "varchar(100)")]
    public string orderId { get; set; } = "";

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string paymentMethod { get; set; } = "VNPAY";

    [Required]
    public string PaymentStatus { get; set; } = string.Empty;

    [Required]
    public long totalAmount { get; set; }

    public string message { get; set; } = string.Empty;

    public DateTime paymentRequestCreatedDate { get; set; }

    [Column(TypeName = "varchar(100)")]
    [ForeignKey(nameof(userModel))]
    [AllowNull]
    public string customerID { get; set; } = "";

    public userModel userModel { get; set; } = null!;

    public List<ticketOrderDetail> ticketOrderDetail = [];
    
    public List<foodOrderDetail> foodOrderDetail { get; set; } = [];
}