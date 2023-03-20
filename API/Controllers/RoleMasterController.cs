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
                
        [HttpGet("{id}")]
        public async Task<ActionResult> GetRoleMaster(string id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoleMaster(RoleMasterDto item)
        {
            return HandleResult(await Mediator.Send(new Create.Command { RoleMaster = item }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(string id, RoleMasterDto item)
        {
            item.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { RoleMaster = item }));
        }

        [HttpGet("{id}", Name = "RoleUserList")]
        [Route("RoleUserList/{id}")]
        public async Task<ActionResult> RoleUserList(string id)		
        {
             return HandleResult(await Mediator.Send(new GroupUserList.Query { RoleName = id }));            
        }


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
