using Application.TableNames;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    public class TableNamesController : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult> GetTableNames()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }
                
        [HttpGet("{id}")]
        public async Task<ActionResult> GetTableName(int id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTableName(TableName item)
        {
            return HandleResult(await Mediator.Send(new Create.Command { TableName = item }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, TableName item)
        {
            item.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { TableName = item }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }

        [AllowAnonymous]
        [HttpGet("TestReq")]
        public TableName TestReq()
        {
            TableName t = new TableName();
            t.Title = DateTime.Now.ToString();
            return t;
        }
    }
}
