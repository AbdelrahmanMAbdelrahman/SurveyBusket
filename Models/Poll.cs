using SurveyBasket.Contracts.Responses;

namespace SurveyBasket.Models
{
    public class Poll
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
        //public static explicit operator PollResponse (Poll poll)
        //{

        //    return new()
        //    {
        //        ID = poll.ID,
        //        Title = poll.Title,
        //        Description = poll.Description
        //    };
        //}
    }

    //public class PollDetails
    //{
    //    public int ID { get; set; }
    //    public int PollID { get; set; }
    //    public string Title { get; set; }
    //}
}
