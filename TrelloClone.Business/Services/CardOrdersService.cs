using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrelloClone.Business.Interfaces;
using TrelloClone.Core.Results.Concrete;
using TrelloClone.Core.Results.Interfaces;
using TrelloClone.DataAccess.Interfaces.Repositories;
using TrelloClone.Dtos.CardOrdersDtos;
using TrelloClone.Entities.DbSets;

namespace TrelloClone.Business.Services
{
    public class CardOrdersService : ICardOrdersService
    {
        private readonly ICardOrdersRepository _cardOrdersRepository;
        private readonly IMapper _mapper;

        public CardOrdersService(ICardOrdersRepository cardOrdersRepository, IMapper mapper)
        {
            _cardOrdersRepository = cardOrdersRepository;
            _mapper = mapper;
        }

        public async Task<IResult> CreateCardOrderAsync(CardOrdersCreateDto createCardOrderDto)
        {
            var cardOrder = _mapper.Map<CardOrders>(createCardOrderDto);
            await _cardOrdersRepository.AddAsync(cardOrder);
            return new SuccessResult("Card order successfully created.");
        }

        public async Task<IResult> UpdateCardOrderAsync(CardOrdersUpdateDto updateCardOrderDto)
        {
            var cardOrder = await _cardOrdersRepository.GetByIdAsync(updateCardOrderDto.Id);
            if (cardOrder == null)
            {
                return new ErrorResult("Card order not found.");
            }

            _mapper.Map(updateCardOrderDto, cardOrder);
            await _cardOrdersRepository.UpdateAsync(cardOrder);
            return new SuccessResult("Card order successfully updated.");
        }

        public async Task<IResult> DeleteCardOrderAsync(Guid cardOrderId)
        {
            var cardOrder = await _cardOrdersRepository.GetByIdAsync(cardOrderId);
            if (cardOrder == null)
            {
                return new ErrorResult("Card order not found.");
            }

            await _cardOrdersRepository.DeleteAsync(cardOrder);
            return new SuccessResult("Card order successfully deleted.");
        }

        public async Task<IDataResult<CardOrdersDto>> GetCardOrderByIdAsync(Guid cardOrderId)
        {
            var cardOrder = await _cardOrdersRepository.GetByIdAsync(cardOrderId);
            if (cardOrder == null)
            {
                return new ErrorDataResult<CardOrdersDto>("Card order not found.");
            }

            var cardOrderDto = _mapper.Map<CardOrdersDto>(cardOrder);
            return new SuccessDataResult<CardOrdersDto>(cardOrderDto, "CardOrder details listed successfully.");
        }

        public async Task<IDataResult<List<CardOrdersDto>>> GetAllCardOrdersByListIdAsync(Guid listId)
        {
            var cardOrders = await _cardOrdersRepository.GetAllAsync(co => co.ListId == listId);
            var cardOrdersDtos = _mapper.Map<List<CardOrdersDto>>(cardOrders);
            return new SuccessDataResult<List<CardOrdersDto>>(cardOrdersDtos, "CardOrders listed successfully.");
        }
    }
}
