using Application.TableFields;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    public class TableFieldsController : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult> GetTableFields()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }
                
        [HttpGet("{id}")]
        public async Task<ActionResult> GetTableField(int id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTableField(TableField item)
        {
            return HandleResult(await Mediator.Send(new Create.Command { TableField = item }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, TableField item)
        {
            item.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { TableField = item }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }

        [AllowAnonymous]
        [HttpGet("TestReq")]
        public TableField TestReq()
        {
            TableField t = new TableField();
            t.Title = DateTime.Now.ToString();
            return t;
        }
    }
}
