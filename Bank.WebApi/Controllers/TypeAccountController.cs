using Bank.Application.Common;
using Bank.Application.TypesAccount.Queries.TypeAccountDetail;
using Bank.Application.TypesAccount.Queries.TypeAccountList;
using Bank.Application.TypesAccount.ViewModels;
using Bank.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Bank.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TypeAccountController : BaseController
    {
        public TypeAccountController()
        {

        }

        [HttpGet("[action]")]
        public Task<WrapperResult<IEnumerable<TypeAccountGetViewModel>>> GetAll() 
        {
            return Mediator.Send(new TypeAccountListQuery());
        }

        [HttpGet("[action]/{typeId}")]
        public Task<WrapperResult<TypeAccountGetViewModel>> Get(Guid typeId) 
        {
            return Mediator.Send(new TypeAccontDetailQuery(typeId));
        }
    }
}
