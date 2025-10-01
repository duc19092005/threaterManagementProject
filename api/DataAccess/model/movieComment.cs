using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.model;

public class movieComment
{
    [Key]
    [Column(TypeName = "varchar(100)")]
    public string commentId { get; set; }
    
    [Column(TypeName = "nvarchar(max)")]
    public string commentContent { get; set; }
    
    [ForeignKey(nameof(movieInformation))]
    [Column(TypeName = "varchar(100)")]
    public string movieId { get; set; }
    
    // Luồng hoạt độg như sau nếu nó là staff th sẽ đc giảm giá tùy vào role của nó 
    // Nếu nó là User thì giá bình thường
    // Nếu nó là Cấp quản lý thì logic sẽ như nhau
    [ForeignKey(nameof(userModel))]
    [Column(TypeName = "varchar(100)")]
    public string userId { get; set; }
    
    public movieInformation movieInformation { get; set; }
    
    public userModel userModel { get; set; }
}