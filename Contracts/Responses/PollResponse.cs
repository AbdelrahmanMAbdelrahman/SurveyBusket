namespace SurveyBasket.Contracts.Responses
{
    public record PollResponse(int ID, string Title, string Description,bool IsPublished,DateOnly StartsAt,DateOnly EndsAt)
    {
        //public int ID { get; set; }
        //public string? Title { get; set; }
        //public string? Description { get; set; }
    }
}
