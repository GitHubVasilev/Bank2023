using Bank.Application.Accounts.Commands.CreateAccount;
using Bank.Application.Accounts.Commands.DeleteCommand;
using Bank.Application.Accounts.Queries.GetAccountDetales;
using Bank.Application.Accounts.Queries.GetAccountList;
using Bank.Application.Accounts.ViewModels.Accounts;
using Bank.Application.Accounts.ViewModels.DepositeAccounts;
using Bank.Application.Accounts.ViewModels.NoDepositeAccounts;
using Bank.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;


namespace Bank.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : BaseController
    {
        public AccountController() { }

        [HttpGet("[action]/{clientId}")]
        public async Task<ActionResult<List<AccountLookupDTO>>> GetFromUser(Guid clientId)
        {
            return Ok(await Mediator.Send(new GetAccountListQuery<AccountLookupDTO>(clientId), ControllerContext.HttpContext.RequestAborted));
        }

        [HttpGet("[action]/{accountId}")]
        public async Task<ActionResult<AccountDetailsViewModel>> Get(Guid accountId)
        {
            return Ok(await Mediator.Send(new GetAccountDetailsQuery<AccountDetailsViewModel>(accountId), ControllerContext.HttpContext.RequestAborted));
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> CreateDeposite([FromBody] DepositeAccountPostViewModel viewModel)
        {
            var command = new CreateDepositeAccountCommand(viewModel);
            await Mediator.Send(command);
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> CreateNoDeposite([FromBody] NoDepositeAccountPostViewModel viewModel)
        {
            var command = new CreateNoDepositeAccountCommand(viewModel);
            await Mediator.Send(command);
            return Ok();
        }

        [HttpDelete("[action]/{accountId}")]
        public async Task<ActionResult> CloseAccount(Guid accountId) 
        {
            var command = new CloseAccountCommand(accountId);
            await Mediator.Send(command);
            return Ok();
        }
    }
}
