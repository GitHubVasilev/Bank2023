using Bank.Application.Accounts.Commands.CreateAccount;
using Bank.Application.Accounts.Queries.GetAccountDetales;
using Bank.Application.Accounts.Queries.GetAccountList;
using Bank.Application.Accounts.ViewModels.DepositeAccounts;
using Bank.Application.Accounts.ViewModels.NoDepositeAccounts;
using Bank.Application.Common;
using Bank.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Bank.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class NoDepositeAccountController : BaseController
    {
        public NoDepositeAccountController()
        {

        }

        [HttpGet("[action]/{clientId}")]
        public async Task<ActionResult<WrapperResult<List<NoDepositeAccountViewModel>>>> GetFromUser(Guid clientId)
        {
            return Ok(await Mediator.Send(new GetNoDepositeAccountListQuery(clientId), ControllerContext.HttpContext.RequestAborted));
        }

        [HttpGet("[action]/{accountId}")]
        public async Task<ActionResult<WrapperResult<NoDepositeAccountViewModel>>> Get(Guid accountId)
        {
            return Ok(await Mediator.Send(new GetNoDepositeAccountDetailsQuery(accountId), ControllerContext.HttpContext.RequestAborted));
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<WrapperResult>> Create([FromBody] DepositeAccountPostViewModel viewModel)
        {
            return Ok(await Mediator.Send(new CreateDepositeAccountCommand(viewModel), ControllerContext.HttpContext.RequestAborted));
        }
    }
}
