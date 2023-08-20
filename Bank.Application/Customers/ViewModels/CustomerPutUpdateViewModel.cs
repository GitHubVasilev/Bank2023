using AutoMapper;
using Bank.Application.Common.Mappings;
using Bank.Domain;

namespace Bank.Application.Customers.ViewModels
{
    public class CustomerPutUpdateViewModel : IMapWith<Customer>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Patronymic { get; set; }
        public string? Telephone { get; set; }
        public string? Passport { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CustomerPutUpdateViewModel, Customer>()
                .ForMember(m => m.UID, opt => opt.MapFrom(m => m.Id))
                .ForMember(m => m.LastName, opt => opt.MapFrom(m => m.LastName))
                .ForMember(m => m.FirstName, opt => opt.MapFrom(m => m.FirstName))
                .ForMember(m => m.Patronymic, opt => opt.MapFrom(m => m.Patronymic))
                .ForMember(m => m.Telephone, opt => opt.MapFrom(m => m.Telephone))
                .ForMember(m => m.Passport, opt => opt.MapFrom(m => m.Passport))
                .ForMember(m => m.UpdatedAt, opt => opt.Ignore())
                .ForMember(m => m.UpdatedBy, opt => opt.Ignore())
                .ForMember(m => m.CreatedAt, opt => opt.MapFrom(m => DateTime.UtcNow))
                .ForMember(m => m.CreatedBy, opt => opt.MapFrom((_, _, _, context) => context.Items[nameof(ApplicationUser)]));
        }
    }
}
