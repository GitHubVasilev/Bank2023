using Bank.Application.Common;
using Bank.Application.Transaction.Commands;
using Bank.Application.Transaction.ViewModels;
using Bank.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Bank.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TransactionController : BaseController
    {
        public TransactionController()
        {
            
        }

        [HttpPut("[action]")]
        public Task<WrapperResult> Create([FromBody] TransactionViewModel dateTransaction) 
        {
            return Mediator.Send(new TrancactionMoneyCommand(dateTransaction), ControllerContext.HttpContext.RequestAborted);
        }
    }
}
