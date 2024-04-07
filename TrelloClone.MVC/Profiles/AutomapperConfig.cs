using AutoMapper;
using TrelloClone.Dtos.CardDtos;
using TrelloClone.Dtos.ListDtos;
using TrelloClone.MVC.Models.CardVMs;
using TrelloClone.MVC.Models.ListVMs;

namespace TrelloClone.MVC.Profiles
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<ListDto, ListDetailsVM>();
            CreateMap<CardDto, CardDetailsVM>();
        }
    }
}
