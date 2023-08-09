using Bank.Application.Accounts.Commands.CreateAccount;
using Bank.Application.Accounts.Commands.DeleteCommand;
using Bank.Application.Accounts.Queries.GetAccountDetales;
using Bank.Application.Accounts.Queries.GetAccountList;
using Bank.Application.Accounts.ViewModels.Accounts;
using Bank.Application.Accounts.ViewModels.DepositeAccounts;
using Bank.Application.Accounts.ViewModels.NoDepositeAccounts;
using Bank.Application.Common;
using Bank.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;


namespace Bank.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : BaseController
    {
        public AccountController() { }

        [HttpGet("[action]/{clientId}")]
        public async Task<ActionResult<WrapperResult<List<AccountLookupDTO>>>> GetFromUser(Guid clientId)
        {
            return Ok(await Mediator.Send(new GetAccountListQuery(clientId), ControllerContext.HttpContext.RequestAborted));
        }

        [HttpGet("[action]/{accountId}")]
        public async Task<ActionResult<WrapperResult<AccountDetailsViewModel>>> Get(Guid accountId)
        {
            return Ok(await Mediator.Send(new GetAccountDetailsQuery(accountId), ControllerContext.HttpContext.RequestAborted));
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<WrapperResult>> CreateDeposite([FromBody] DepositeAccountPostViewModel viewModel)
        {
            return Ok(await Mediator.Send(new CreateDepositeAccountCommand(viewModel), ControllerContext.HttpContext.RequestAborted));
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<WrapperResult>> CreateNoDeposite([FromBody] NoDepositeAccountPostViewModel viewModel)
        {
            return Ok(await Mediator.Send(new CreateNoDepositeAccountCommand(viewModel), ControllerContext.HttpContext.RequestAborted));
        }

        [HttpDelete("[action]/{accountId}")]
        public async Task<ActionResult<WrapperResult>> CloseAccount(Guid accountId) 
        {
            return Ok(await Mediator.Send(new CloseAccountCommand(accountId), ControllerContext.HttpContext.RequestAborted));
        }
    }
}
