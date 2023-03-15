using Application.RoleMasters;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    public class RoleMastersController : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult> GetRoleMasters()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }
                
        // [HttpGet("{id}")]
        // public async Task<ActionResult> GetRoleMaster(int id)
        // {
        //     return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        // }

        // [HttpPost]
        // public async Task<IActionResult> CreateRoleMaster(RoleMaster item)
        // {
        //     return HandleResult(await Mediator.Send(new Create.Command { RoleMaster = item }));
        // }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> Edit(int id, RoleMaster item)
        // {
        //     item.Id = id;
        //     return HandleResult(await Mediator.Send(new Edit.Command { RoleMaster = item }));
        // }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> Delete(int id)
        // {
        //     return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        // }

        // [AllowAnonymous]
        // [HttpGet("TestReq")]
        // public RoleMaster TestReq()
        // {
        //     RoleMaster t = new RoleMaster();
        //     t.Title = DateTime.Now.ToString();
        //     return t;
        // }
    }
}