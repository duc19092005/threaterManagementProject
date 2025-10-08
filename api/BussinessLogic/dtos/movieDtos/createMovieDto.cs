using Microsoft.AspNetCore.Http;

namespace BussinessLogic.dtos.movieDtos;
using DataAccess.Enums;

// Dtos for create Movie Only 

public class createMovieDto
{
    public string movieName { get; set; }
    
    public string movieDescription { get; set; }
    
    public IFormFile movieImage { get; set; }
    
    public string movieDirector { get; set; } 
    
    public string [] movieActors { get; set; }
    
    public string movieTrailerURL { get; set; }
    
    public int movieDuration { get; set; }
    
    public DateTime movieReleaseDate { get; set; }
    
    public DateTime movieEndedData { get; set; }
    
    public languageEnum movieLanguage { get; set; }
    
    public miniumAgeEnum movieRequireAge { get; set; }
    
    public string [] movieVisualFormatIds {get; set;}
    
    public string [] movieGenreIds { get; set; }
    
}