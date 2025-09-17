using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.model;

public class roleModel
{
    [Key]
    [Column(TypeName = "varchar(150)")]
    public string roleId { get; set; } = string.Empty;
    
    [Column(TypeName = "nvarchar(40)")]
    public string? roleName { get; set; }
    
    public List<userRoleModel> userRoleModel { get; set; } = null!;
}