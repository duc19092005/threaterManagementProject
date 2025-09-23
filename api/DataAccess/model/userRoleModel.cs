using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.model;

public partial class userRoleModel
{
    [ForeignKey(nameof(userModel))]
    [Column(TypeName = "varchar(150)")]
    public string userId { get; set; } = string.Empty;
    
    [ForeignKey(nameof(roleModel))]
    [Column(TypeName = "varchar(150)")]
    public string roleId { get; set; } = string.Empty;
    
    public userModel? userModel { get; set; }
    
    public roleModel? roleModel { get; set; }
    
}

[PrimaryKey("userId" , "roleId")]
public partial class userRoleModel
{
    
}