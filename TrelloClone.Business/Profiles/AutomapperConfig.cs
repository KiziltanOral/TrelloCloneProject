using AutoMapper;
using TrelloClone.Dtos.CardDtos;
using TrelloClone.Dtos.CardOrdersDtos;
using TrelloClone.Dtos.ListDtos;
using TrelloClone.Entities.DbSets;

namespace TrelloClone.Business.Profiles
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<List, ListDto>()
                .ForMember(dest => dest.Cards, opt => opt.MapFrom(src => src.CardOrders.Select(co => co.Card)));
            CreateMap<ListCreateDto, List>();
            CreateMap<ListUpdateDto, List>();

            CreateMap<Card, CardDto>()
                .ForMember(dest => dest.CardOrderId, opt => opt.MapFrom(src => src.CardOrder.Id));
            CreateMap<CardCreateDto, Card>();
                //.ForMember(dest => dest.CardOrder, opt => opt.MapFrom(src => new CardOrders { ListId = src.ListId }))
                //.ForMember(dest => dest.CardOrder, opt => opt.MapFrom(src => new CardOrders { Index = src.Index }));
            CreateMap<CardUpdateDto, Card>()
            .ForMember(dest => dest.CardOrder, opt => opt.MapFrom(src => new CardOrders { ListId = src.NewListId }));

            CreateMap<CardOrders, CardOrdersDto>().ReverseMap();
            CreateMap<CardOrdersCreateDto, CardOrders>();
            CreateMap<CardOrdersUpdateDto, CardOrders>()
                .ForMember(dest => dest.Index, opt => opt.MapFrom(src => src.NewIndex));
        }
    }
}
