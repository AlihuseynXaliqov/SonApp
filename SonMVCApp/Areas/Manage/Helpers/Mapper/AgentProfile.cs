using AutoMapper;
using SonMVCApp.Areas.Manage.ViewModels.Agent;
using SonMVCApp.Models;

namespace SonMVCApp.Areas.Manage.Helpers.Mapper
{
    public class AgentProfile:Profile
    {
        public AgentProfile()
        {
            CreateMap<Agent, UpdateAgentVm>().ReverseMap();
            CreateMap<Agent, CreateAgentVm>().ReverseMap();
        }
    }
}
