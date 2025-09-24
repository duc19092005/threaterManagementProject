using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DataAccess.model;

public class userModel
{
    [Key]
    [Column(TypeName = "varchar(150)")]
    public string userId { get; set; } = string.Empty;

    [Column(TypeName = "varchar(150)")]
    [NotNull]
    public string username { get; set; } = string.Empty;
    
    [Column(TypeName = "varchar(255)")]
    [NotNull]
    public string password { get; set; } = string.Empty;

    public List<userRoleModel> userRoleModel { get; set; } = null!;
    
    public customerModel customerModel { get; set; } = null!;
}