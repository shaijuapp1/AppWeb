using Application.AppConfigTypes;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    public class AppConfigTypesController : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult> GetAppConfigTypes()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }
                
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAppConfigType(int id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppConfigType(AppConfigType item)
        {
            return HandleResult(await Mediator.Send(new Create.Command { AppConfigType = item }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, AppConfigType item)
        {
            item.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { AppConfigType = item }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }

        [AllowAnonymous]
        [HttpGet("TestReq")]
        public AppConfigType TestReq()
        {
            AppConfigType t = new AppConfigType();
            t.Title = DateTime.Now.ToString();
            return t;
        }
    }
}
