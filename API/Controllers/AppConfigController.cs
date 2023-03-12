using Application.AppConfigs;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    public class AppConfigsController : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult> GetAppConfigs()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }
                
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAppConfig(int id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppConfig(AppConfig item)
        {
            return HandleResult(await Mediator.Send(new Create.Command { AppConfig = item }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, AppConfig item)
        {
            item.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { AppConfig = item }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }

        [AllowAnonymous]
        [HttpGet("TestReq")]
        public AppConfig TestReq()
        {
            AppConfig t = new AppConfig();
            t.Title = DateTime.Now.ToString();
            return t;
        }
    }
}
