using Application.ActionTackerTypesLists;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    public class ActionTackerTypesListsController : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult> GetActionTackerTypesLists()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }
                
        [HttpGet("{id}")]
        public async Task<ActionResult> GetActionTackerTypesList(int id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateActionTackerTypesList(ActionTackerTypesListDto item)
        {
            return HandleResult(await Mediator.Send(new Create.Command { ActionTackerTypesList = item }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, ActionTackerTypesListDto item)
        {
            item.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { ActionTackerTypesList = item }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }

        // [AllowAnonymous]
        // [HttpGet("TestReq")]
        // public ActionTackerTypesList TestReq()
        // {
        //     ActionTackerTypesList t = new ActionTackerTypesList();
        //     t.Title = DateTime.Now.ToString();
        //     return t;
        // }
    }
}
