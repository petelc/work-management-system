using Application.Requests;
using Domain;
using Application.Profiles;
using Application.Projects;

namespace Application.Core
{
    public class MappingProfiles : AutoMapper.Profile
    {
        public MappingProfiles()
        {
            //string currentUsername = null;
            CreateMap<Request, Request>();
            CreateMap<Request, RequestDto>()
                .ForMember(d => d.RequestorUsername, o => o.MapFrom(s => s.Requestors.FirstOrDefault().AppUser.UserName));
            //.ForMember(d => d.Project, o => o.MapFrom(s => s.Project.ProjectId == s.Project.ProjectId));
            // ! Create map for requestors to requestordto
            CreateMap<Requestor, RequestorDto>()
                .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.AppUser.DisplayName))
                .ForMember(d => d.Username, o => o.MapFrom(s => s.AppUser.UserName))
                .ForMember(d => d.Bio, o => o.MapFrom(s => s.AppUser.Bio))
                .ForMember(d => d.Title, o => o.MapFrom(s => s.AppUser.Title))
                .ForMember(d => d.Phone, o => o.MapFrom(s => s.AppUser.Phone));
            CreateMap<Project, ProjectDto>()
                .ForMember(d => d.project, o => o.MapFrom(s => s.project))
                .ForMember(d => d.description, o => o.MapFrom(s => s.description));

        }

    }
}