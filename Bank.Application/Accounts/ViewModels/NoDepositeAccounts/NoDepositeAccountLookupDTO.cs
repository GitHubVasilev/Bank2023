using AutoMapper;
using Bank.Application.Accounts.ViewModels.Base;
using Bank.Application.Common.Mappings;
using Bank.Domain;


namespace Bank.Application.Accounts.ViewModels.NoDepositeAccounts
{
    public record NoDepositeAccountLookupDTO : BaseAccountViewModel, IMapWith<Account>
    {
        /// <summary>
        /// Процент по вкладу
        /// </summary>
        public int Procent { get; init; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NoDepositeAccountPostViewModel, Account>()
                .ForMember(m => m.UID, opt => opt.MapFrom(acc => acc.UID))
                .ForMember(m => m.Name, opt => opt.MapFrom(acc => acc.Name))
                .ForMember(m => m.ClientId, opt => opt.MapFrom(acc => acc.UIDClient))
                .ForMember(m => m.TypeAccountId, opt => opt.MapFrom(acc => acc.TypeAccountId))
                .ForMember(m => m.DateOpen, opt => opt.MapFrom(acc => DateTime.UtcNow))
                .ForMember(m => m.CountMonetaryUnit, opt => opt.MapFrom(acc => 0))
                .ForMember(m => m.IsLock, opt => opt.MapFrom(acc => false))
                .ForMember(m => m.IsClose, opt => opt.MapFrom(acc => false))
                .ForMember(m => m.Procent, opt => opt.MapFrom(acc => 0));
        }
    }
}
