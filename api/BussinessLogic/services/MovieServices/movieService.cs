using BussinessLogic.Result;
using BussinessLogic.validations.movieValidations;
using DataAccess.dbConnection;
using DataAccess.model;
using Microsoft.EntityFrameworkCore;

namespace BussinessLogic.services.MovieServices;


public class movieService : IMovieService
{
    private readonly threaterManagementDbContext _context;
    public movieService(threaterManagementDbContext context)
    {
        this._context = context;
    }
    public async Task<baseResultForCRUD> createMovie(dtos.movieDtos.createMovieDto createMovieDto)
    {
        // Lưu thông tin vào database trước tiên check lỗi trước
        
        var getStatus = moviesValidation.createValidate(createMovieDto);

        if (!getStatus.Item1 && getStatus.Item2 != null)
        {
            return baseResultForCRUD.failedStatus(getStatus.Item2);
        }
        
        // Giả sử bắt đầu làm phần thêm ảnh vào cloud
        string imageURL = "";
        
        // Bắt đầu Transaction
        await using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                string movieId = Guid.NewGuid().ToString();
                // Lưu lại thông tin phim 
                await _context.MovieInformation.AddAsync(new movieInformation()
                {
                    movieName = createMovieDto.movieName,
                    movieActor = string.Join(",", createMovieDto.movieActors),
                    miniAge = createMovieDto.movieRequireAge,
                    movieImage = imageURL,
                    movieDescription = createMovieDto.movieDescription,
                    movieDirector = createMovieDto.movieDirector,
                    movieTrailerUrl = createMovieDto.movieTrailerURL,
                    movieDuration = createMovieDto.movieDuration,
                    releaseDate = createMovieDto.movieReleaseDate,
                    endedDate = createMovieDto.movieEndedData,
                    movieLanguage = createMovieDto.movieLanguage,
                    movieId = movieId,
                });

                // Continue Add Movie Genres 

                List<movieGenre> movieGenres = new List<movieGenre>();

                foreach (var genreId in createMovieDto.movieGenreIds)
                {
                    movieGenres.Add(new movieGenre()
                    {
                        movieId = movieId,
                        genereId = genreId
                    });
                }

                await _context.MovieGenres.AddRangeAsync(movieGenres);

                // Continue Add Movie VisualFormat
                List<movieVisualFormat> movieVisualFormats = new List<movieVisualFormat>();

                foreach (var visualFormatId in createMovieDto.movieVisualFormatIds)
                {
                    movieVisualFormats.Add(new movieVisualFormat()
                    {
                        movieId = movieId,
                        visualFormatId = visualFormatId
                    });
                }

                await _context.MovieVisualFormats.AddRangeAsync(movieVisualFormats);

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return baseResultForCRUD.successStatus("Thêm phim thành công !");
            }
            catch (DbUpdateException dbUpdateException)
            {
                // Database Error Return
                return baseResultForCRUD.failedStatus("Lỗi Khi Thêm Phim");
            }
            catch (Exception ex)
            {
                return baseResultForCRUD.failedStatus("Lỗi hệ thống vui lòng thử lại sau");
            }
        }
    }

    public async Task<baseResultForCRUD> editMovie(dtos.movieDtos.editMovieDto editMovieDto)
    {
        return null!;
    }
}