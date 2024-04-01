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

        public CardService(ICardRepository cardRepository, IMapper mapper)
        {
            _cardRepository = cardRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<CardDetailsDto>> CreateCardAsync(CardCreateDto cardCreateDto)
        {
            var cardEntity = _mapper.Map<Card>(cardCreateDto);
            await _cardRepository.AddAsync(cardEntity);
            var cardReadDto = _mapper.Map<CardDetailsDto>(cardEntity);
            return new SuccessDataResult<CardDetailsDto>(cardReadDto, "Card successfully created.");
        }

        public async Task<IResult> UpdateCardAsync(CardUpdateDto cardUpdateDto)
        {
            var cardEntity = await _cardRepository.GetByIdAsync(cardUpdateDto.Id);
            if (cardEntity == null)
            {
                return new ErrorResult("Card not found.");
            }

            _mapper.Map(cardUpdateDto, cardEntity);
            await _cardRepository.SaveChangesAsync();
            return new SuccessResult("Card successfully updated.");
        }

        public async Task<IResult> DeleteCardAsync(Guid id)
        {
            var cardEntity = await _cardRepository.GetByIdAsync(id);
            if (cardEntity == null)
            {
                return new ErrorResult("Card not found.");
            }

            await _cardRepository.DeleteAsync(cardEntity);
            await _cardRepository.SaveChangesAsync();
            return new SuccessResult("Card successfully deleted.");
        }

        public async Task<IDataResult<IEnumerable<CardDetailsDto>>> GetAllCardsAsync()
        {
            var cards = await _cardRepository.GetAllAsync();
            var cardDetailDtos = _mapper.Map<IEnumerable<CardDetailsDto>>(cards);
            return new SuccessDataResult<IEnumerable<CardDetailsDto>>(cardDetailDtos, "Cards successfully retrieved.");
        }

        public async Task<IDataResult<CardDetailsDto>> GetCardByIdAsync(Guid id)
        {
            var card = await _cardRepository.GetByIdAsync(id);
            if (card == null)
            {
                return new ErrorDataResult<CardDetailsDto>("Card not found.");
            }

            var cardDetailDto = _mapper.Map<CardDetailsDto>(card);
            return new SuccessDataResult<CardDetailsDto>(cardDetailDto, "Card successfully retrieved.");
        }
    }
}
