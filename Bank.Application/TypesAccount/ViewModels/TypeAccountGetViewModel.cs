using AutoMapper;
using Bank.Application.Common.Mappings;
using Bank.Domain;

namespace Bank.Application.TypesAccount.ViewModels
{
    public class TypeAccountGetViewModel : IMapWith<TypeAccount>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TypeAccount, TypeAccountGetViewModel>()
                .ForMember(m => m.Id, opt => opt.MapFrom(m => m.UID))
                .ForMember(m => m.Name, opt => opt.MapFrom(m => m.Name));
        }
    }
}
