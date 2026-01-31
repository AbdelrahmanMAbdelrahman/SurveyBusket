using SurveyBasket.Contracts.Responses;
using System.ComponentModel.DataAnnotations;

namespace SurveyBasket.Models
{
    public class Poll
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="must provide title")]
        [MaxLength(100,ErrorMessage = "can't exceed 255 character")]
        [Length(1, 100,ErrorMessage ="must be in range from 0 to 255")]
        
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsPublished { get; set; }
        public DateOnly StartsAt { get; set; }
        public DateOnly EndsAt { get; set; }

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
