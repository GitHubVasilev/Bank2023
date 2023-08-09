using Bank.Application.Common;
using Bank.Application.PutAndWithdraw.Commands;
using Bank.Application.PutAndWithdraw.ViewModels;
using Bank.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Bank.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PutAndWithdrawController : BaseController
    {
        public PutAndWithdrawController()
        {

        }

        [HttpPut("[action]")]
        public async Task<ActionResult<WrapperResult>> Put([FromBody] PutAndWithdrawViewModel dataPut) 
        {
            return Ok(await Mediator.Send(new PutMoneyCommand(dataPut), ControllerContext.HttpContext.RequestAborted));
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<WrapperResult>> Withdraw([FromBody] PutAndWithdrawViewModel dataWithdraw)
        {
            return Ok(await Mediator.Send(new PutMoneyCommand(dataWithdraw), ControllerContext.HttpContext.RequestAborted));
        }
    }
}
