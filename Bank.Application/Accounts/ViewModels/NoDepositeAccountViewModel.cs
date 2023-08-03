using AutoMapper;
using Bank.Application.Accounts.ViewModels.Base;
using Bank.Domain;

namespace Bank.Application.Accounts.ViewModels
{
    /// <summary>
    /// Объект для передачи данных недепозитного счета
    /// </summary>
    public record NoDepositeAccountViewModel : BaseAccountViewModel
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Account, NoDepositeAccountViewModel>()
                .ForMember(m => m.UID, opt => opt.MapFrom(acc => acc.UID))
                .ForMember(m => m.Name, opt => opt.MapFrom(acc => acc.Name))
                .ForMember(m => m.UIDClient, opt => opt.MapFrom(acc => acc.ClientId))
                .ForMember(m => m.TypeAccountId, opt => opt.MapFrom(acc => acc.TypeAccountId))
                .ForMember(m => m.DateOpen, opt => opt.MapFrom(acc => acc.DateOpen))
                .ForMember(m => m.CountMonetaryUnit, opt => opt.MapFrom(acc => acc.CountMonetaryUnit))
                .ForMember(m => m.IsLock, opt => opt.MapFrom(acc => acc.IsLock))
                .ForMember(m => m.IsClose, opt => opt.MapFrom(acc => acc.IsClose));
        }
    }
}
