using Application.##Class##s;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    public class ##Class##sController : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult> Get##Class##s()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }
                
        [HttpGet("{id}")]
        public async Task<ActionResult> Get##Class##(int id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Create##Class##(##Class## item)
        {
            return HandleResult(await Mediator.Send(new Create.Command { ##Class## = item }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, ##Class## item)
        {
            item.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { ##Class## = item }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }

        [AllowAnonymous]
        [HttpGet("TestReq")]
        public ##Class## TestReq()
        {
            ##Class## t = new ##Class##();
            t.Title = DateTime.Now.ToString();
            return t;
        }
    }
}