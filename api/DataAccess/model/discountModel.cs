using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.model;

// Cho nó là Unique
[Index(nameof(roleId) , IsUnique = true)]
public class discountModel
{
    // Mức độ đãi ngộ cho các Role cần thiết
    
    [Key]
    [Column(TypeName = "varchar(100)")]
    public string roleId { get; set; }
    
    // Đây là thông tin cho khuyến mãi
    // Giả sử nếu staff thì khuyến mãi 20% cho mỗi lần mua
    // Cái này cos thể mở rộng được
    [Column(TypeName = "float")]
    public float discountNumber { get; set; }
    
    public roleModel roleModel { get; set; } = null!;
}