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
            // CreateMap<RequestToRequestors, RequestorDto>()
            //     .ForMember(x => x.DisplayName, o => o.MapFrom(s => s.Employee.DisplayName))
            //     .ForMember(x => x.Username, o => o.MapFrom(s => s.Employee.UserName))
            //     .ForMember(x => x.LastName, o => o.MapFrom(s => s.Employee.LastName))
            //     .ForMember(x => x.FirstName, o => o.MapFrom(s => s.Employee.FirstName))
            //     .ForMember(x => x.Region, o => o.MapFrom(s => s.Employee.Region))
            //     .ForMember(x => x.Institution, o => o.MapFrom(s => s.Employee.Institution))
            //     .ForMember(x => x.Extension, o => o.MapFrom(s => s.Employee.Extension))
            //     .ForMember(x => x.ReportsTo, o => o.MapFrom(s => s.Employee.ReportsTo));
        }
    }
}