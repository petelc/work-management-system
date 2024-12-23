using Application.Requests;
using Application.CABs;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : AutoMapper.Profile
    {
        public MappingProfiles()
        {
            //string currentUsername = null;
            CreateMap<Request, Request>();
            CreateMap<RequestDto, Request>();
            CreateMap<Request, RequestDto>()
                .ForMember(d => d.RequestorUsername, o => o.MapFrom(s => s.Requestor.UserName))
                .ForMember(d => d.RequestTypeName, o => o.MapFrom(s => s.RequestType.RequestTypeName))
                .ForMember(d => d.RequestType, o => o.MapFrom(s => s.RequestType))
                .ForMember(d => d.StatusName, o => o.MapFrom(s => s.Status.StatusName))
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status))
                .ForMember(d => d.ApprovalStatusName, o => o.MapFrom(s => s.ApprovalStatus.ApprovalStatusName))
                .ForMember(d => d.ApprovalStatus, o => o.MapFrom(s => s.ApprovalStatus))
                .ForMember(d => d.Change, o => o.MapFrom(s => s.Change))
                .ForMember(d => d.Project, o => o.MapFrom(s => s.Project))
                .ForMember(d => d.Requestor, o => o.MapFrom(s => s.Requestor));
            CreateMap<CAB, CAB>();
            CreateMap<CABDto, CAB>();
            CreateMap<CAB, CABDto>()
                .ForMember(d => d.Request, o => o.MapFrom(s => s.Request))
                .ForMember(d => d.Member, o => o.MapFrom(s => s.Member))
                .ForMember(d => d.Change, o => o.MapFrom(s => s.Change))
                .ForMember(d => d.Project, o => o.MapFrom(s => s.Project));
                
        }
    }
}