using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.model;

public partial class foodOrderDetail
{
    [Required]
    [ForeignKey(nameof(orderModel))]
    public string orderId { get; set; } = "";

    [Required]
    [ForeignKey(nameof(productModel))]
    public string foodInformationId { get; set; } = "";

    public int quanlity { get; set; }
        
    public decimal PriceEach { get; set; }
        
    public orderModel orderModel { get; set; } = null!;

    public productModel productModel { get; set; } = null!;
}

[PrimaryKey(nameof(orderId) , nameof(foodInformationId))]
public partial class foodOrderDetail
{
    
}