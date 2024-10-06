using Application.Requests;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : AutoMapper.Profile
    {
        public MappingProfiles()
        {
            //string currentUsername = null;
            CreateMap<Request, Request>();
            CreateMap<Request, RequestDto>();
            // .ForMember(d => d.Requestors, o => o.MapFrom(s => s.Requestors
            //     .FirstOrDefault(x => x.IsNew).Employee.UserName));
            // CreateMap<RequestToRequestors, RequestorDto>()
            //     .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.Employee.DisplayName))
            //     .ForMember(d => d.Username, o => o.MapFrom(s => s.Employee.UserName))
            //     .ForMember(d => d.LastName, o => o.MapFrom(s => s.Employee.LastName))
            //     .ForMember(d => d.FirstName, o => o.MapFrom(s => s.Employee.FirstName))
            //     .ForMember(d => d.Region, o => o.MapFrom(s => s.Employee.Region))
            //     .ForMember(d => d.Institution, o => o.MapFrom(s => s.Employee.Institution))
            //     .ForMember(d => d.Extension, o => o.MapFrom(s => s.Employee.Extension))
            //     .ForMember(d => d.ReportsTo, o => o.MapFrom(s => s.Employee.ReportsTo))
            //     .ForMember(d => d.IsRequestor,
            //         o => o.MapFrom(s => s.Employee.Requests.Any(x => x.Employee.UserName == currentUsername)));


        }
    }
}