using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrelloClone.Core.Results.Interfaces;
using TrelloClone.Dtos.CardOrdersDtos;

namespace TrelloClone.Business.Interfaces
{
    public interface ICardOrdersService
    {
        Task<IDataResult<CardOrdersDto>> GetCardOrderByIdAsync(Guid cardOrderId);
        Task<IDataResult<List<CardOrdersDto>>> GetAllCardOrdersByListIdAsync(Guid listId);
        Task<IResult> CreateCardOrderAsync(CardOrdersCreateDto createCardOrderDto);
        Task<IResult> UpdateCardOrderAsync(CardOrdersUpdateDto updateCardOrderDto);
        Task<IResult> DeleteCardOrderAsync(Guid cardOrderId);
    }
}
