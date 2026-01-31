using SurveyBasket.Data;
using SurveyBasket.Models;

namespace SurveyBasket.Services
{
    public class PollService(DatabaseContext _context) : IPollService
    {
       
        public async Task<bool> commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task Create(Poll poll, CancellationToken token)
        {
            await _context.Polls.AddAsync(poll);
        }

        public async Task Delete(int Id, CancellationToken token)
        {
            Poll? poll = await _context.Polls.FindAsync(Id);
            if (poll == null) return;
             
                  _context.Polls.Remove(poll);
             
        }

        public async Task<Poll>? Get(int Id, CancellationToken token)
        {
            return await _context.Polls.FindAsync(Id);
        }

        public async Task<IEnumerable<Poll>> GetAll(CancellationToken token)
        {
           return await  _context.Polls.ToListAsync();
        }
        
        public async Task Publish(int Id, CancellationToken token)
        {
            Poll? dbPoll = await _context.Polls.FindAsync(Id);
            if (dbPoll == null) return;
            dbPoll.IsPublished = !dbPoll.IsPublished;
        }
        
        public async Task Update(int ID, Poll poll, CancellationToken token)
        {
            Poll? dbPoll=await _context.Polls.FindAsync(ID);
            if (dbPoll == null) return ;
            dbPoll.IsPublished = poll.IsPublished;
            dbPoll.Title = poll.Title;
            dbPoll.Description = poll.Description;
            dbPoll.StartsAt = poll.StartsAt;
            dbPoll.EndsAt = poll.EndsAt;
        }
    }
}
