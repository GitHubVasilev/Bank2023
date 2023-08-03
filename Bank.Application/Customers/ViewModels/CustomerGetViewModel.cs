using AutoMapper;
using Bank.Application.Common.Mappings;
using Bank.Domain;

namespace Bank.Application.Customers.ViewModels
{
    public class CustomerGetViewModel : IMapWith<Customer>
    {
        public Guid UID { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Patronymic { get; set; }
        public string? Telephone { get; set; }
        public string? Passport { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }

        public void Mapping(Profile profile) 
        {
            profile.CreateMap<Customer, CustomerGetViewModel>()
                .ForMember(m => m.UID, opt => opt.MapFrom(m => m.UID))
                .ForMember(m => m.FirstName, opt => opt.MapFrom(m => m.FirstName))
                .ForMember(m => m.LastName, opt => opt.MapFrom(m => m.LastName))
                .ForMember(m => m.Patronymic, opt => opt.MapFrom(m => m.Patronymic))
                .ForMember(m => m.Telephone, opt => opt.MapFrom(m => m.Telephone))
                .ForMember(m => m.Passport, opt => opt.MapFrom(m => m.Passport))
                .ForMember(m => m.CreatedAt, opt => opt.MapFrom(m => m.CreatedAt))
                .ForMember(m => m.CreatedBy, opt => opt.MapFrom(m => m.CreatedBy))
                .ForMember(m => m.UpdatedAt, opt => opt.MapFrom(m => m.UpdatedAt))
                .ForMember(m => m.UpdatedBy, opt => opt.MapFrom(m => m.UpdatedBy));
        }
    }
}
