

using SurveyBasket.Models;
using SurveyBasket.Services;
using System.Reflection.Metadata.Ecma335;

namespace SurveyBasket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollsController(IPollService polls) : ControllerBase
    {
      
        [HttpGet(Name ="Polls")]
        public IActionResult GetAll()
        {
            var Polls = polls.GetAll();
            return Polls.Count()>0?Ok(Polls):NotFound();
        }
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            Poll? poll = polls.Get(Id) ;
            return poll == null ? NotFound() : Ok(poll);
        }

        [HttpPost("")]
        public  IActionResult  Add(Poll? poll)
        {
            if (poll == null) BadRequest("fill poll data");
             
                Poll? newPoll= polls.Create(poll);
            return newPoll != null ?
                CreatedAtAction(nameof(GetById), new { ID = newPoll.ID }, newPoll):
                BadRequest("could not create poll");

        }

        [HttpPut("")]
        public IActionResult Update(Poll? poll)
        {
            if(poll==null)BadRequest("fill poll data");
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
    }
}
