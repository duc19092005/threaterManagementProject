using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.model;

public class cinemaRoomModel
{
    [Key]
    [Column(TypeName = "varchar(100)")]
    public string cinemaRoomId { get; set; } = null!;
    
    // Đây là số phòng của phòng chiếu nó như sau
    // A01 , B01 hay gì đó tùy vào mng đặt
    
    
    public string cinemaRoomNumber { get; set; } = null!;
    
    // Khóa ngoại
    [ForeignKey(nameof(visualFormatId))]
    public string visualFormatId { get; set; } = null!;
    
    // Khóa ngoại để biết định dạng
    public visualFormat visualFormat { get; set; } = null!;
    
    [ForeignKey(nameof(cinemaRoomId))]
    public string cinemaId { get; set; }
    
    public List<seatsModel> seatsModel { get; set; } = null!;
    
    public Cinema Cinema { get; set; } = null!;
}