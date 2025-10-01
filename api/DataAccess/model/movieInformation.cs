using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Enums;

namespace DataAccess.model;

public class movieInformation
{
    // Id của bộ phim 
        [Key]
        [Column(TypeName = "varchar(100)")]
        public string movieId { get; set; } = "";

        // Tên của bộ phim

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string movieName { get; set; } = "";

        [Required]
        public string movieImage { get; set; } = string.Empty;

        // Miêu tả của bộ phim

        [Required]
        [Column(TypeName = "nvarchar(max)")]

        public string movieDescription { get; set; } = "";

        // Đạo diễn của bộ phim
        [Required]
        [Column(TypeName = "nvarchar(200)")]

        public string movieDirector { get; set; } = "";

        // Diễn viên của bộ phim
        [Required]
        [Column(TypeName = "nvarchar(300)")]
        public string movieActor { get; set; } = "";

        // url Lưu trữ trailer của bộ phim

        [Required]
        [Column(TypeName = "varchar(300)")]
        public string movieTrailerUrl { get; set; } = "";

        // Thời lượng của bộ phim --------------!--------------- Chú ý : Tính bằng phút --------------!---------------
        
        [Required]
        public int movieDuration { get; set; }

        [Required]
        public DateTime releaseDate { get; set; }
        
        [Required]
        public DateTime endedDate { get; set; }

        [Required]
        public bool isDelete { get; set; } = false;

        [ForeignKey("Language")]
        [Column(TypeName = "varchar(100)")]
        
        [Required]
        public languageEnum  movieLanguage { get; set; }
        
        
        [Required]
        public miniumAgeEnum miniAge { get; set; }
        
        public List<movieVisualFormat> movieVisualFormat = [];
        
        //
        public List<movieSchedule> movieSchedule { get; set; } = null!;
        // Khóa ngoại 1 bộ phim có nhiều comment

        public List<movieGenre> movieGenreInformation { get; set; } = [];

        public List<movieComment> movieComment { get; set; } = [];
    
}