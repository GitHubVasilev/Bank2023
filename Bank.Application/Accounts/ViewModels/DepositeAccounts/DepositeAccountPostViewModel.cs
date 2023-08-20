using AutoMapper;
using Bank.Application.Common.AppConfig;
using Bank.Application.Common.Mappings;
using Bank.Domain;

namespace Bank.Application.Accounts.ViewModels.DepositeAccounts
{
    public class DepositeAccountPostViewModel : IMapWith<Account>
    {
        /// <summary>
        /// Идентификтатор счета
        /// </summary>
        public Guid UID { get; init; }
        /// <summary>
        /// Название счета
        /// </summary>
        public string? Name { get; init; }
        /// <summary>
        /// Идентификатор клиента которому принадлежит счет
        /// </summary>
        public Guid ClientId { get; init; }
        /// <summary>
        /// Определяет можно ли производить денежные операции
        /// </summary>
        public bool IsLock { get; init; }
        /// <summary>
        /// Процент по вкладу
        /// </summary>
        public int Procent { get; init; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DepositeAccountPostViewModel, Account>()
                .ForMember(m => m.UID, opt => opt.MapFrom(acc => acc.UID))
                .ForMember(m => m.Name, opt => opt.MapFrom(acc => acc.Name))
                .ForMember(m => m.ClientId, opt => opt.MapFrom(acc => acc.ClientId))
                .ForMember(m => m.TypeAccountId, opt => opt.MapFrom(acc => AccountsDomain.DepositeAccountId))
                .ForMember(m => m.DateOpen, opt => opt.MapFrom(acc => DateTime.UtcNow))
                .ForMember(m => m.CountMonetaryUnit, opt => opt.MapFrom(acc => 0))
                .ForMember(m => m.IsLock, opt => opt.MapFrom(acc => acc.IsLock))
                .ForMember(m => m.IsClose, opt => opt.MapFrom(acc => false))
                .ForMember(m => m.Procent, opt => opt.MapFrom(acc => acc.Procent));
        }
    }
}
