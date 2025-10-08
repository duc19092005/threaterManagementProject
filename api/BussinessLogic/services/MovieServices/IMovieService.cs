using BussinessLogic.Result;

namespace BussinessLogic.services.MovieServices;

public interface IMovieService
{
    Task<baseResultForCRUD> createMovie(dtos.movieDtos.createMovieDto createMovieDto);
    
    Task<baseResultForCRUD> editMovie(dtos.movieDtos.editMovieDto editMovieDto);
}