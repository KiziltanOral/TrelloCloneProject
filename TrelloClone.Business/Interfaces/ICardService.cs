using TrelloClone.Core.Results.Interfaces;
using TrelloClone.Dtos.CardDtos;

namespace TrelloClone.Business.Interfaces
{
    public interface ICardService
    {
        Task<IDataResult<CardDto>> GetCardByIdAsync(Guid cardId);
        Task<IDataResult<List<CardDto>>> GetAllCardsAsync();
        Task<IDataResult<CardDto>> CreateCardAsync(CardCreateDto createCardDto);
        Task<IResult> UpdateCardAsync(CardUpdateDto updateCardDto);
        Task<IResult> DeleteCardAsync(Guid cardId);
        Task<IResult> MoveCardToAnotherListAsync(Guid cardId, Guid targetListId, int targetIndex);
        Task<IResult> MoveCardWithinListAsync(Guid cardId, int targetIndex);
    }
}
