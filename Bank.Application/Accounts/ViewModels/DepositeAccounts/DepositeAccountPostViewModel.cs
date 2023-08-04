using AutoMapper;
using Bank.Application.Accounts.ViewModels.Base;
using Bank.Domain;

namespace Bank.Application.Accounts.ViewModels.DepositeAccounts
{
    public class DepositeAccountPostViewModel : BaseAccountPostViewModel
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<DepositeAccountViewModel, Account>()
                .ForMember(m => m.UID, opt => opt.MapFrom(acc => acc.UID))
                .ForMember(m => m.Name, opt => opt.MapFrom(acc => acc.Name))
                .ForMember(m => m.ClientId, opt => opt.MapFrom(acc => acc.ClientId))
                .ForMember(m => m.TypeAccountId, opt => opt.MapFrom(acc => acc.TypeAccountId))
                .ForMember(m => m.DateOpen, opt => opt.MapFrom(acc => DateTime.UtcNow))
                .ForMember(m => m.CountMonetaryUnit, opt => opt.MapFrom(acc => 0))
                .ForMember(m => m.IsLock, opt => opt.MapFrom(acc => false))
                .ForMember(m => m.IsClose, opt => opt.MapFrom(acc => false));
        }
    }
}
