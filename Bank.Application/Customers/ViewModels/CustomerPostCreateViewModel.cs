using AutoMapper;
using Bank.Application.Common.Mappings;
using Bank.Domain;

namespace Bank.Application.Customers.ViewModels
{
    public class CustomerPostCreateViewModel : IMapWith<Customer>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = string.Empty;
        public string Patronymic { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Passpost { get; set; } = string.Empty;

        public void Mapping(Profile profile) 
        {
            profile.CreateMap<CustomerPostCreateViewModel, Customer>()
                .ForMember(m => m.UID, opt => opt.MapFrom(m => m.Id))
                .ForMember(m => m.LastName, opt => opt.MapFrom(m => m.LastName))
                .ForMember(m => m.FirstName, opt => opt.MapFrom(m => m.FirstName))
                .ForMember(m => m.Patronymic, opt => opt.MapFrom(m => m.Patronymic))
                .ForMember(m => m.Telephone, opt => opt.MapFrom(m => m.Phone))
                .ForMember(m => m.Passport, opt => opt.MapFrom(m => m.Passpost))
                .ForMember(m => m.UpdatedAt, opt => opt.Ignore())
                .ForMember(m => m.UpdatedBy, opt => opt.Ignore())
                .ForMember(m => m.CreatedAt, opt => opt.MapFrom(m => DateTime.UtcNow))
                .ForMember(m => m.CreatedBy, opt => opt.MapFrom((_, _, _, context) => context.Items[nameof(ApplicationUser)]));
        }
    }
}
