using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.model;

public partial class cinemaProductModel
{
    [ForeignKey(nameof(productModel))]
    public string cinemaId { get; set; }
    
    [ForeignKey(nameof(Cinema))]
    public string productId { get; set; }
    
    public string productAmount { get; set; }

    public Cinema Cinema { get; set; } = null!;

    public productModel productModel { get; set; } = null!;
}

[PrimaryKey(nameof(cinemaId) , nameof(productId))]
public partial class cinemaProductModel
{
    
}