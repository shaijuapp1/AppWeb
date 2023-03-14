using Application.UserManagers;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    public class UserManagersController : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult> GetUserList()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }
                
        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserManager(string Username)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Username = Username }));
        }

      

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, AppUser item)
        {
            //item.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { UserManager = item }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }

        [AllowAnonymous]
        [HttpGet("TestReq")]
        public ContentResult TestReq()
        {
            var html = "Click on <a href='##SiteURL##'>link</a> to open this request<br/>";
            return base.Content(html, "text/html");
            //return DateTime.Now.ToString();
        }
    }
}
