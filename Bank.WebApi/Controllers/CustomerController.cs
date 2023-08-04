using Bank.Application.Accounts.ViewModels.Accounts;
using Bank.Application.Common;
using Bank.Application.Customers.Commands.CreateCustomer;
using Bank.Application.Customers.Commands.DeleteCustomer;
using Bank.Application.Customers.Commands.UpdateCustomer;
using Bank.Application.Customers.Queries.GetCustomerDetails;
using Bank.Application.Customers.ViewModels;
using Bank.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Bank.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : BaseController
    {
        public CustomerController()
        {

        }

        [HttpGet("[action]/{customerId}")]
        public async Task<ActionResult<WrapperResult<AccountDetailsViewModel>>> Get(Guid customerId)
        {
            return Ok(await Mediator.Send
                (
                    new GetCustomerDelailsQuery(customerId, ControllerContext.HttpContext.User), ControllerContext.HttpContext.RequestAborted)
                );
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<WrapperResult>> Create([FromBody] CustomerPostCreateViewModel viewModel)
        {
            return Ok(await Mediator.Send
                (
                    new CreateCustomerCommand(viewModel, ControllerContext.HttpContext.User), ControllerContext.HttpContext.RequestAborted)
                );
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<WrapperResult>> Update([FromBody] CustomerPutUpdateViewModel viewModel)
        { 
            return Ok(await Mediator.Send
                (
                    new UpdateCustomerCommand(viewModel, ControllerContext.HttpContext.User), ControllerContext.HttpContext.RequestAborted)
                );
        }

        [HttpDelete("[action]/{customerId}")]
        public async Task<ActionResult<WrapperResult>> Delete(Guid customerId) 
        {
            return Ok(await Mediator.Send
                (
                    new DeleteCustomerCommand(customerId), ControllerContext.HttpContext.RequestAborted
                ));
        }
    }
}
