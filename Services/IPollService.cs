using SurveyBasket.Contracts.Requests;
using SurveyBasket.Contracts.Responses;
using SurveyBasket.Models;

namespace SurveyBasket.Services
{
    public interface IPollService
    {
        Task<IEnumerable<Poll>> GetAll(CancellationToken token);
       Task< Poll>? Get(int Id,CancellationToken token);
       Task  Create(Poll poll,CancellationToken token);

       Task Update(int ID ,Poll poll,CancellationToken token);
       Task Delete(int Id, CancellationToken token);
        Task Publish(int Id, CancellationToken token);
         Task<bool> commit();
    }
}
