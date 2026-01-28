using Mapster;
using SurveyBasket.Contracts.Responses;

namespace SurveyBasket.Mapping
{
    public class MappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Poll, PollResponse>().Map(des=>des.Description,src=>src.Description);
            config.NewConfig<Poll, PollResponse>().Map(des=>des.ID,src=>src.ID);
            config.NewConfig<Student, StudentResponse>().Map(des => des.ID, src => src.ID).
                Map(des=>des.age,src=>src.DateOfBirth.HasValue? DateTime.Now.Year- src.DateOfBirth.Value.Year:0);//cs1061 HasValue
        }
    }
}
