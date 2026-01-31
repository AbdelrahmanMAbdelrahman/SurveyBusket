

using FluentValidation;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SurveyBasket.Contracts.Requests;
using SurveyBasket.Contracts.Responses;
using SurveyBasket.Mapping;
using SurveyBasket.Models;
using SurveyBasket.Services;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace SurveyBasket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollsController(IPollService polls) : ControllerBase
    {
      
        [HttpGet(Name ="Polls")]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var Polls =await polls.GetAll(token);
            IEnumerable<PollResponse> res = Polls.Adapt<IEnumerable< PollResponse>>();//mapper.Map<List<PollResponse>>(Polls);
            return Polls.Count()>0?Ok(res) :NotFound();
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id, CancellationToken token)
        {
           Poll poll =await polls.Get(Id,   token) ;
            PollResponse res=poll.Adapt<PollResponse>();
            return poll == null ? NotFound() : Ok(res);
        }

        [HttpPost("")]
        public  async Task<IActionResult>  Add([FromBody] PollRequest req,CancellationToken token
            //, [FromServices]IValidator<PollRequest>pollValidator
            )
        {
            //var validationResult=pollValidator.Validate(poll);
            //if (!validationResult.IsValid)
            //{
            //    var modelState =new ModelStateDictionary();
            //    foreach (var item in validationResult.Errors)
            //    {
            //        modelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //    }
            //    return ValidationProblem(modelState);
            //}
             
             Poll poll=req.Adapt<Poll>();
            
             await polls.Create(poll,token);
            PollResponse res=poll.Adapt<PollResponse>();
            return await polls.commit() ?
                CreatedAtAction(nameof(GetById), new { ID = poll.ID }, res):
                BadRequest("could not create poll");

        }

        [HttpPut("")]
        public async Task<IActionResult> Update(int ID,PollRequest? req,CancellationToken token)
        {Poll poll=req.Adapt<Poll>();
            if (poll==null)BadRequest("fill poll data");

            await polls.Update(ID,poll,token);
            return await polls.commit()?
                NoContent() :
              NotFound("could not find poll");
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete (int Id,CancellationToken token)
        {
            await polls.Delete(Id,token);
            return await polls.commit()?
                NoContent() :
              NotFound("could not find poll");
        }
        [HttpPost("test")]
        public IActionResult TestStudent([FromBody]Student std) {
            return Ok("data is valid");
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
        [HttpPut("{Id}/Publish")]
        public async Task<IActionResult> Publish(int Id,CancellationToken token)
        {
            await polls.Publish(Id,token);
            return await polls.commit() ? NoContent() : NotFound("no poll found for this id");
        }
    }
}
