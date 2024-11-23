using AutoMapper;
using caso_de_estudio_1_backend.DTOs;
using caso_de_estudio_1_backend.Models;

namespace caso_de_estudio_1_backend.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Associate Mappings
            CreateMap<Associate, AssociateDto>()
                .ForMember(dest => dest.FullName,
                           opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
            CreateMap<AssociateCreateDto, Associate>();
            CreateMap<AssociateUpdateDto, Associate>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // CurriculumVitae Mappings
            CreateMap<CurriculumVitae, CurriculumVitaeDto>();
            CreateMap<CurriculumVitaeCreateDto, CurriculumVitae>()
                .ForMember(x => x.File, options => options.Ignore())
                .ForMember(dest => dest.UploadDate,
                           opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.LastUpdated,
                           opt => opt.MapFrom(src => DateTime.UtcNow));
            CreateMap<CurriculumVitaeUpdateDto, CurriculumVitae>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Payment Mappings
            CreateMap<Payment, PaymentDto>();
            CreateMap<PaymentCreateDto, Payment>()
                .ForMember(dest => dest.PaymentDate,
                           opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Status,
                           opt => opt.MapFrom(src => "Paid"));
            CreateMap<PaymentUpdateDto, Payment>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<JobOffer, JobOfferDto>().ReverseMap();
            CreateMap<JobApplication, JobApplicationDto>().ReverseMap();
            CreateMap<Event, EventDto>().ReverseMap();
            CreateMap<EventRegistration, EventRegistrationDto>().ReverseMap();
        }
    }
}
