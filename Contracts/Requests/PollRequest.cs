namespace SurveyBasket.Contracts.Requests
{
    public record PollRequest(  string Title, string Description)
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
