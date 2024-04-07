using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrelloClone.Core.Results.Interfaces;
using TrelloClone.Dtos.ListDtos;

namespace TrelloClone.Business.Interfaces
{
    public interface IListService
    {
        Task<IDataResult<ListDto>> GetListByIdAsync(Guid listId);
        Task<IDataResult<List<ListDto>>> GetAllListsAsync();
        Task<IDataResult<ListDto>> CreateListAsync(ListCreateDto createListDto);
        Task<IResult> UpdateListAsync(ListUpdateDto updateListDto);
        Task<IResult> DeleteListAsync(Guid listId);
    }

}
