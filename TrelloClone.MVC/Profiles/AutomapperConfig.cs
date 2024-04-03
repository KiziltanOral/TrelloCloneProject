using AutoMapper;
using TrelloClone.Dtos.ListDtos;
using TrelloClone.MVC.Models.ListVMs;

namespace TrelloClone.MVC.Profiles
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<ListUpdateVM, ListUpdateDto>().ReverseMap();
            CreateMap<ListDetailsDto, ListDetailsVM>().ReverseMap();
        }
    }
}
