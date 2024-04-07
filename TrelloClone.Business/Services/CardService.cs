using AutoMapper;
using TrelloClone.Business.Interfaces;
using TrelloClone.Core.Results.Concrete;
using TrelloClone.Core.Results.Interfaces;
using TrelloClone.DataAccess.Interfaces.Repositories;
using TrelloClone.Dtos.CardDtos;
using TrelloClone.Entities.DbSets;

namespace TrelloClone.Business.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        private readonly IMapper _mapper;
        private readonly ICardOrdersRepository _cardOrdersRepository;

        public CardService(ICardRepository cardRepository, IMapper mapper, ICardOrdersRepository cardOrdersRepository)
        {
            _cardRepository = cardRepository;
            _mapper = mapper;
            _cardOrdersRepository = cardOrdersRepository;
        }

        public async Task<IDataResult<CardDto>> CreateCardAsync(CardCreateDto createCardDto)
        {
            var card = _mapper.Map<Card>(createCardDto);
            var createdCard = await _cardRepository.AddAsync(card);

            var cardOrders = await _cardOrdersRepository.GetAllAsync(co => co.ListId == createCardDto.ListId);
            var newIndex = cardOrders.Any() ? cardOrders.Max(co => co.Index) + 1 : 0;
            
            var conflictingOrder = cardOrders.FirstOrDefault(co => co.Index == newIndex);
            if (conflictingOrder != null)
            {
                foreach (var co in cardOrders.Where(co => co.Index >= newIndex))
                {
                    co.Index++;
                    await _cardOrdersRepository.UpdateAsync(co);
                }
            }

            var cardOrder = new CardOrders
            {
                CardId = createdCard.Id,
                ListId = createCardDto.ListId,
                Index = newIndex
            };
            await _cardOrdersRepository.AddAsync(cardOrder);
            await _cardOrdersRepository.SaveChangesAsync();
            await _cardRepository.SaveChangesAsync();

            var cardDto = _mapper.Map<CardDto>(createdCard);
            return new SuccessDataResult<CardDto>(cardDto, "Card successfully created.");
        }

        public async Task<IResult> UpdateCardAsync(CardUpdateDto updateCardDto)
        {
            var card = await _cardRepository.GetByIdAsync(updateCardDto.Id);
            if (card == null )
            {
                return new ErrorResult("Card not found.");
            }

            _mapper.Map(updateCardDto, card);
            await _cardRepository.UpdateAsync(card);

            var cardOrder = await _cardOrdersRepository.GetAsync(x => x.CardId == card.Id);
            if (cardOrder != null && cardOrder.ListId != updateCardDto.NewListId)
            {
                cardOrder.ListId = updateCardDto.NewListId;
                await _cardOrdersRepository.UpdateAsync(cardOrder);
            }

            return new SuccessResult("Card successfully updated.");
        }

        public async Task<IResult> DeleteCardAsync(Guid cardId)
        {
            var card = await _cardRepository.GetByIdAsync(cardId);
            if (card == null)
            {
                return new ErrorResult("Card not found.");
            }

            var cardOrder = await _cardOrdersRepository.GetAsync(co => co.CardId == cardId);
            if (cardOrder == null)
            {
                return new ErrorResult("Card order not found.");
            }

            var cardOrdersToUpdate = await _cardOrdersRepository.GetAllAsync(co => co.ListId == cardOrder.ListId && co.Index > cardOrder.Index);
            foreach(var co in cardOrdersToUpdate)
            {
                co.Index--;
                await _cardOrdersRepository.UpdateAsync(co);
            }

            await _cardOrdersRepository.DeleteAsync(cardOrder);
            await _cardRepository.DeleteAsync(card);

            return new SuccessResult("Card successfully deleted.");
        }

        public async Task<IDataResult<CardDto>> GetCardByIdAsync(Guid cardId)
        {
            var card = await _cardRepository.GetByIdAsync(cardId);
            if (card == null)
            {
                return new ErrorDataResult<CardDto>("Card not found.");
            }

            var cardDto = _mapper.Map<CardDto>(card);
            return new SuccessDataResult<CardDto>(cardDto, "Card details listed succesfully.");
        }

        public async Task<IDataResult<List<CardDto>>> GetAllCardsAsync()
        {
            var cards = await _cardRepository.GetAllCardsWithOrdersAsync();
            var cardDtos = _mapper.Map<List<CardDto>>(cards);
            return new SuccessDataResult<List<CardDto>>(cardDtos, "Cards listed succesfully.");
        }

        public async Task<IResult> MoveCardWithinListAsync(Guid cardId, int targetIndex)
        {
            var cardOrder = await _cardOrdersRepository.GetAsync(co => co.CardId == cardId);
            if (cardOrder == null)
            {
                return new ErrorResult("Card or card order not found.");
            }

            var currentListCardOrders = await _cardOrdersRepository.GetAllAsync(co => co.ListId == cardOrder.ListId && co.CardId != cardId);
            int currentIndex = cardOrder.Index;

            if (targetIndex > currentIndex)
            {
                foreach (var co in currentListCardOrders.Where(co => co.Index > currentIndex && co.Index <= targetIndex))
                {
                    co.Index--;
                    await _cardOrdersRepository.UpdateAsync(co);
                }
            }
            else if (targetIndex < currentIndex)
            {
                foreach (var co in currentListCardOrders.Where(co => co.Index < currentIndex && co.Index >= targetIndex))
                {
                    co.Index++;
                    await _cardOrdersRepository.UpdateAsync(co);
                }
            }

            cardOrder.Index = targetIndex;
            await _cardOrdersRepository.UpdateAsync(cardOrder);

            return new SuccessResult($"Card moved successfully within the list.");
        }

        public async Task<IResult> MoveCardToAnotherListAsync(Guid cardId, Guid targetListId, int targetIndex)
        {
            var cardOrder = await _cardOrdersRepository.GetAsync(co => co.CardId == cardId);
            if (cardOrder == null)
            {
                return new ErrorResult("Card or card order not found.");
            }

            var oldListCardOrders = await _cardOrdersRepository.GetAllAsync(co => co.ListId == cardOrder.ListId && co.CardId != cardId);
            foreach (var co in oldListCardOrders.Where(co => co.Index > cardOrder.Index))
            {
                co.Index--;
                await _cardOrdersRepository.UpdateAsync(co);
            }

            var newListCardOrders = await _cardOrdersRepository.GetAllAsync(co => co.ListId == targetListId);
            foreach (var co in newListCardOrders.Where(co => co.Index >= targetIndex))
            {
                co.Index++;
                await _cardOrdersRepository.UpdateAsync(co);
            }

            cardOrder.ListId = targetListId;
            cardOrder.Index = targetIndex;
            await _cardOrdersRepository.UpdateAsync(cardOrder);

            return new SuccessResult("Card moved successfully to another list.");
        }
    }
}
