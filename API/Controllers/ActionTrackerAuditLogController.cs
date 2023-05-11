using Application.ActionTrackerAuditLogs;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    public class ActionTrackerAuditLogsController : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult> GetActionTrackerAuditLogs()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }
                
        [HttpGet("{id}")]
        public async Task<ActionResult> GetActionTrackerAuditLog(int id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateActionTrackerAuditLog(ActionTrackerAuditLog item)
        {
            return HandleResult(await Mediator.Send(new Create.Command { ActionTrackerAuditLog = item }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, ActionTrackerAuditLog item)
        {
            item.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { ActionTrackerAuditLog = item }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }

        [HttpGet("{LogList}/{type}/{id}")]
        public async Task<ActionResult> LogList(string type, int id)
        {
            return HandleResult(await Mediator.Send(new LogList.Query { type = type, Id = id }));
        }

        [HttpGet("TestReq")]
        public ActionTackerTaskList TestConfig()
        {
            ActionTackerTaskList t = new ActionTackerTaskList();
            t.Title = DateTime.Now.ToString();
            t.Test = "123";
            return t;
        }
    }
}
