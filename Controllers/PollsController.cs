

using Mapster;
using MapsterMapper;
using SurveyBasket.Contracts.Requests;
using SurveyBasket.Contracts.Responses;
using SurveyBasket.Mapping;
using SurveyBasket.Models;
using SurveyBasket.Services;
using System.Reflection.Metadata.Ecma335;

namespace SurveyBasket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollsController(IPollService polls,IMapper mapper) : ControllerBase
    {
      
        [HttpGet(Name ="Polls")]
        public IActionResult GetAll()
        {
            var Polls = polls.GetAll();
            IEnumerable<PollResponse> res = Polls.Adapt<IEnumerable< PollResponse>>();//mapper.Map<List<PollResponse>>(Polls);
            return Polls.Count()>0?Ok(res) :NotFound();
        }
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            Poll? poll = polls.Get(Id) ;
            PollResponse res=mapper.Map<PollResponse>(poll);
            return poll == null ? NotFound() : Ok(res);
        }

        [HttpPost("")]
        public  IActionResult  Add([FromBody] PollRequest poll)
        {
            if (poll == null) BadRequest("fill poll data");
             Poll req=mapper.Map<Poll>(poll);
            req.ID = PollService.Polls.Count() + 1;
            Poll? newPoll= polls.Create(req);
            PollResponse res=mapper.Map<PollResponse>(newPoll);
            return newPoll != null ?
                CreatedAtAction(nameof(GetById), new { ID = newPoll.ID }, res):
                BadRequest("could not create poll");

        }

        [HttpPut("")]
        public IActionResult Update(PollRequest? req)
        {Poll poll=mapper.Map<Poll>(req);
            if (poll==null)BadRequest("fill poll data");

            return polls.Update(poll)?
                NoContent() :
              NotFound("could not find poll");
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete (int Id)
        {
            return polls.Delete(Id)?
                NoContent() :
              NotFound("could not find poll");
        }
        [HttpGet("test")]
        public IActionResult TestStudent()
        {
            Student student = new()
            {
                ID = 1,
                FirstName = "addo",
                MiddleName = "abo",
                LastName = "hussien",
                DateOfBirth=new DateTime(2004,4,10),
                PollTitle="student Poll"

            };
            StudentResponse res = student.Adapt<StudentResponse>();
            return Ok(res);
        }
    }
}
