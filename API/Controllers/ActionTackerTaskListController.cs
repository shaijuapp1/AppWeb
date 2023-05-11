using Application.ActionTackerTaskLists;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    public class ActionTackerTaskListsController : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult> GetActionTackerTaskLists(string status )
        {
            // if(string.IsNullOrEmpty(status)){
            //     status = "*";
            // }
            return HandleResult(await Mediator.Send(new List.Query{status=status}));
        }
                
        [HttpGet("{id}")]
        public async Task<ActionResult> GetActionTackerTaskList(int id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateActionTackerTaskList(ActionTackerTaskListDto item)
        {
            return HandleResult(await Mediator.Send(new Create.Command { ActionTackerTaskList = item }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, ActionTackerTaskListDto item)
        {
            item.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { ActionTackerTaskList = item }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }

        // [AllowAnonymous]
        // [HttpGet("TestReq")]
        // public ActionTackerTaskList TestReq()
        // {
        //     ActionTackerTaskList t = new ActionTackerTaskList();
        //     t.Title = DateTime.Now.ToString();
        //     return t;
        // }
    }
}
