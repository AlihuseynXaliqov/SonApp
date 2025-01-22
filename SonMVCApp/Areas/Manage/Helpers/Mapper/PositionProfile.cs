using AutoMapper;
using SonMVCApp.Areas.Manage.ViewModels.Position;
using SonMVCApp.Models;

namespace SonMVCApp.Areas.Manage.Helpers.Mapper
{
    public class PositionProfile:Profile
    {
        public PositionProfile()
        {
           CreateMap<Position, UpdatePositionVm>().ReverseMap();
           CreateMap<Position, CreatePositionVm>().ReverseMap();

        }
    }
}
