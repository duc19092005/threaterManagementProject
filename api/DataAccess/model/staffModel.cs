using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.model;

public class staffModel
{
    [Key]
    [Column(TypeName = "varchar(100)")]
    public string staffId { get; set; } = null!;
    
    [Column(TypeName = "nvarchar(50)")]
    public string staffName { get; set; } = null!;

    // Khúc này cần mã hóa nha
    [Column(TypeName = "varchar(100)")]
    [Required]
    public string staffIdentityCode { get; set; } = null!;
    
    [Column(TypeName = "varchar(100)")]
    [Required]
    public string userId { get; set; } = null!;
    
    // Staff có liên quan đến Cinema nha
    [ForeignKey(nameof(Cinema))]
    public string cinemaId { get; set; } = null!;
    
    public Cinema Cinema { get; set; } = null!;
}