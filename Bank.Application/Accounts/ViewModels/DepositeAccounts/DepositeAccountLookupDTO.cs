using AutoMapper;
using Bank.Application.Accounts.ViewModels.Accounts;
using Bank.Application.Accounts.ViewModels.Base;
using Bank.Application.Common.Mappings;
using Bank.Domain;

namespace Bank.Application.Accounts.ViewModels.DepositeAccounts
{
    public record DepositeAccountLookupDTO : BaseAccountViewModel, IMapWith<Account>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Account, AccountDetailsViewModel>()
                .ForMember(m => m.UID, opt => opt.MapFrom(m => m.UID))
                .ForMember(m => m.Name, opt => opt.MapFrom(m => m.Name))
                .ForMember(m => m.CountMonetaryUnit, opt => opt.MapFrom(m => m.CountMonetaryUnit))
                .ForMember(m => m.TypeAccountId, opt => opt.MapFrom(m => m.TypeAccountId))
                .ForMember(m => m.TypeAccountName, opt => opt.MapFrom(m => m.TypeAccount.Name))
                .ForMember(m => m.IsLock, opt => opt.MapFrom(m => m.IsLock))
                .ForMember(m => m.IsClose, opt => opt.MapFrom(m => m.IsClose))
                .ForMember(m => m.ClientId, opt => opt.MapFrom(m => m.ClientId));
        }
    }
}
