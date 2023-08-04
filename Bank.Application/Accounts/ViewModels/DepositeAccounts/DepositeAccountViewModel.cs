using AutoMapper;
using Bank.Application.Accounts.ViewModels.Base;
using Bank.Application.Common.Mappings;
using Bank.Domain;

namespace Bank.Application.Accounts.ViewModels.DepositeAccounts
{
    /// <summary>
    /// Объект для передачи данных депозитного счета
    /// </summary>
    public sealed record DepositeAccountViewModel : BaseAccountViewModel, IMapWith<Account>
    {
        /// <summary>
        /// Процент по вкладу
        /// </summary>
        public int Procent { get; init; }

        public void Mapping(Profile profile) 
        {
            profile.CreateMap<Account, DepositeAccountViewModel>()
                .ForMember(m => m.UID, opt => opt.MapFrom(acc => acc.UID))
                .ForMember(m => m.Name, opt => opt.MapFrom(acc => acc.Name))
                .ForMember(m => m.ClientId, opt => opt.MapFrom(acc => acc.ClientId))
                .ForMember(m => m.TypeAccountId, opt => opt.MapFrom(acc => acc.TypeAccountId))
                .ForMember(m => m.DateOpen, opt => opt.MapFrom(acc => acc.DateOpen))
                .ForMember(m => m.CountMonetaryUnit, opt => opt.MapFrom(acc => acc.CountMonetaryUnit))
                .ForMember(m => m.IsLock, opt => opt.MapFrom(acc => acc.IsLock))
                .ForMember(m => m.IsClose, opt => opt.MapFrom(acc => acc.IsClose))
                .ForMember(m => m.Procent, opt => opt.MapFrom(acc => acc.Procent));
        }   
    }
}
