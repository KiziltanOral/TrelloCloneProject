using TrelloClone.Core.Results.Interfaces;
using TrelloClone.Dtos.CardDtos;

namespace TrelloClone.Business.Interfaces
{
    public interface ICardService
    {
        Task<IDataResult<CardDetailsDto>> CreateCardAsync(CardCreateDto cardCreateDto);
        Task<IResult> UpdateCardAsync(CardUpdateDto cardUpdateDto);
        Task<IResult> DeleteCardAsync(Guid id);
        Task<IDataResult<IEnumerable<CardDetailsDto>>> GetAllCardsAsync();
        Task<IDataResult<CardDetailsDto>> GetCardByIdAsync(Guid id);
    }
}
