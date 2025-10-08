using BussinessLogic.dtos.movieDtos;
using BussinessLogic.Result;

namespace BussinessLogic.validations.movieValidations;

public class moviesValidation
{
    public static (bool,string ?message) createValidate(createMovieDto createMovieDto)
    {
        if (createMovieDto.movieReleaseDate > DateTime.Now)
        {
            return (false , "Lỗi Thời gian ra mắt phải lớn hơn hoặc bằng thời gian hện tại");
        }else if (createMovieDto.movieEndedData < createMovieDto.movieReleaseDate)
        {
            return (false , "Lỗi thời gian kết thúc phải lớn hơn thời gian ra mắt");
        }else if (!createMovieDto.movieVisualFormatIds.Any())
        {
            return (false , "Lỗi định dạng hình ảnh bị để trống");
        }else if (!createMovieDto.movieGenreIds.Any())
        {
            return (false , "Lỗi thể loại phim bị để trống");
        }

        return (true, null);
    }

    public static baseResultForCRUD editValidate(editMovieDto editMovieDto)
    {
        return null!;
    }

}