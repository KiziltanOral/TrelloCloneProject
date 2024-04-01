using AutoMapper;
using TrelloClone.Dtos.BoardDtos;
using TrelloClone.Dtos.CardDtos;
using TrelloClone.Dtos.ListDtos;
using TrelloClone.Entities.DbSets;

namespace TrelloClone.Business.Profiles
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Card, CardDetailsDto>();
            CreateMap<CardCreateDto, Card>();
            CreateMap<CardUpdateDto, Card>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<List, ListDetailsDto>();
            CreateMap<ListCreateDto, List>();
            CreateMap<ListUpdateDto, List>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Board, BoardDetailsDto>();
            CreateMap<BoardCreateDto, Board>();
            CreateMap<BoardUpdateDto, Board>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
