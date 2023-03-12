using Application.DataSecuritys;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    public class DataSecuritysController : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult> GetDataSecuritys()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }
                
        [HttpGet("{id}")]
        public async Task<ActionResult> GetDataSecurity(int id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateDataSecurity(DataSecurity item)
        {
            return HandleResult(await Mediator.Send(new Create.Command { DataSecurity = item }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, DataSecurity item)
        {
            item.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { DataSecurity = item }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
      
    }
}
