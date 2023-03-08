using Application.ToDos;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    public class ToDosController : BaseApiController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> GetActivities()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }
        
        [Authorize(Policy = "IsDevAdmin")]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetToDo(int id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateToDo(ToDo toDo)
        {
            return HandleResult(await Mediator.Send(new Create.Command { ToDo = toDo }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, ToDo toDo)
        {
            toDo.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { ToDo = toDo }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }

        [AllowAnonymous]
        [HttpGet("TestReq")]
        public ToDo TestReq()
        {
            ToDo t = new ToDo();
            t.Title = DateTime.Now.ToString();
            return t;
        }
    }
}