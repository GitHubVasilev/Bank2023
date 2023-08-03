using AutoMapper;
using Bank.Application.Common.Mappings;
using Bank.Domain;

namespace Bank.Application.Accounts.Queries.GetAccountDetales
{
    public class AccountDetailsViewModel : IMapWith<Account>
    {
        public Guid UID { get; set; }
        public string Name { get; set; } = null!;
        public int Procent { get; set; }
        public decimal CountMonetaryUnit { get; set; }
        public Guid TypeAccountId { get; set; }
        public string TypeAccountName { get; set; } = null!;
        public bool IsLock { get; set; }
        public bool IsClose { get; set; }
        public Guid? ClientId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Account, AccountDetailsViewModel>()
                .ForMember(m => m.UID, opt => opt.MapFrom(m => m.UID))
                .ForMember(m => m.Name, opt => opt.MapFrom(m => m.Name))
                .ForMember(m => m.Procent, opt => opt.MapFrom(m => m.Procent))
                .ForMember(m => m.CountMonetaryUnit, opt => opt.MapFrom(m => m.CountMonetaryUnit))
                .ForMember(m => m.TypeAccountId, opt => opt.MapFrom(m => m.TypeAccountId))
                .ForMember(m => m.TypeAccountName, opt => opt.MapFrom(m => m.TypeAccount.Name))
                .ForMember(m => m.IsLock, opt => opt.MapFrom(m => m.IsLock))
                .ForMember(m => m.IsClose, opt => opt.MapFrom(m => m.IsClose))
                .ForMember(m => m.ClientId, opt => opt.MapFrom(m => m.ClientId));
        }
    }
}
