using Bank.Application.Accounts.Commands.CreateAccount;
using Bank.Application.Accounts.Commands.DeleteCommand;
using Bank.Application.Accounts.Queries.GetAccountDetales;
using Bank.Application.Accounts.Queries.GetAccountList;
using Bank.Application.Accounts.ViewModels;
using Bank.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;


namespace Bank.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : BaseController
    {
        public AccountController() { }

        [HttpGet("[action]")]
        public async Task<ActionResult> Pink()
        {
            await Task.Delay(0);
            return Ok();
        }

        [HttpGet("[action]/{clientId}")]
        public async Task<ActionResult<AccountListViewModel>> GetFromUser(Guid clientId)
        {
            GetAccountListQuery query = new GetAccountListQuery() { ClientId = clientId };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("[action]/{accountId}")]
        public async Task<ActionResult<AccountDetailsViewModel>> Get(Guid accountId)
        {
            GetAccountDetailsQuery query = new GetAccountDetailsQuery() { UID = accountId };
            var vm = await Mediator.Send(query);
            return Ok(vm);
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
