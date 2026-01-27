using SurveyBasket.Models;

namespace SurveyBasket.Services
{
    public interface IPollService
    {
        IEnumerable<Poll> GetAll();
        Poll? Get(int Id);
        Poll? Create(Poll poll);

        bool Update(Poll poll);
        bool Delete(int Id);
    }
}
