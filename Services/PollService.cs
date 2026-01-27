using SurveyBasket.Models;

namespace SurveyBasket.Services
{
    public class PollService : IPollService
    {

        static List<Poll> Polls = [
          new Poll{
            ID=1,
            Title="my Polls",
            Description="Polls Desc"
            }
          ];

        public bool Delete(int Id)
        {
            Poll? poll= Polls.FirstOrDefault(p => p.ID == Id);
            if (poll == null) return false;
          return  Polls.Remove(poll);
        }

        public Poll? Get(int Id) => Polls.FirstOrDefault(p => p.ID == Id);
        

        public IEnumerable<Poll> GetAll()=> Polls;

        public bool Update(Poll poll)
        {
            Poll? dbPoll = Polls.FirstOrDefault(p => p.ID == poll.ID);
            if (dbPoll == null) return false;
            dbPoll.Description = poll.Description;
            dbPoll.Title = poll.Title;
            return true;
        }

        Poll? IPollService.Create(Poll poll)
        {
            poll.ID = Polls.Count + 1;
           Polls.Add(poll);
              return poll;
        }

       
    }
}
