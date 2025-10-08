using BussinessLogic.dtos.movieDtos;
using BussinessLogic.Enums;
using BussinessLogic.Result;

namespace BussinessLogic.validations.movieValidations;

public class moviesValidation
{
    public static (bool,string ?message , crudStatus crudStatusE) createValidate(createMovieDto createMovieDto)
    {
        if (createMovieDto.movieReleaseDate > DateTime.Now)
        {
            return (false , "Lỗi Thời gian ra mắt phải lớn hơn hoặc bằng thời gian hện tại" , crudStatus.FieldError);
        }else if (createMovieDto.movieEndedData < createMovieDto.movieReleaseDate)
        {
            return (false , "Lỗi thời gian kết thúc phải lớn hơn thời gian ra mắt" , crudStatus.FieldError);
        }else if (!createMovieDto.movieVisualFormatIds.Any())
        {
            return (false , "Lỗi định dạng hình ảnh bị để trống" , crudStatus.FieldError);
        }else if (!createMovieDto.movieGenreIds.Any())
        {
            return (false , "Lỗi thể loại phim bị để trống" , crudStatus.FieldError);
        }

        return (true, null , crudStatus.SuccessFully);
    }

    public static baseResultForCRUD editValidate(editMovieDto editMovieDto)
    {
        return null!;
    }

}