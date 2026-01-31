using System.ComponentModel.DataAnnotations;
using SurveyBasket.ValidationAttributeFolder;
namespace SurveyBasket.Contracts.Requests
{
    public record PollRequest(
        //[Required(ErrorMessage ="must provide title")]
        //[MaxLength(100,ErrorMessage = "can't exceed 100 character")]
        //[Length(1, 100,ErrorMessage ="must be in range from 1 to 100")]
         
        string Title,
        [MaxLength(100,ErrorMessage = "can't exceed 100 character")]
        string Description
        , bool IsPublished, DateOnly StartsAt, DateOnly EndsAt)
    {
        //public string? Title { get; set; }
        //public string? Description { get; set; }
        //public static explicit operator Poll?( PollRequest request)
        //{
        //    return new()
        //    {
        //        Title = request.Title ?? string.Empty,
        //        Description = request.Description ?? string.Empty
        //    };
        //}
    }
}
