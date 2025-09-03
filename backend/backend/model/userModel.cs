using System.ComponentModel.DataAnnotations;

namespace backend.model;

public class userModel
{
    [Key]
    public string id { get; set; }

    public string name { get; set; }
}