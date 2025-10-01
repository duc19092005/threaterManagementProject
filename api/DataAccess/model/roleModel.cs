using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.model;

public class roleModel
{
    [Key]
    [Column(TypeName = "varchar(100)")]
    public string roleId { get; set; } = string.Empty;
    
    [Column(TypeName = "nvarchar(40)")]
    public string roleName { get; set; } = string.Empty;
    
    public List<userRoleModel> userRoleModel { get; set; } = null!;
}