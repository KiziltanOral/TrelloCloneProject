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
        Task<IDataResult<ListDetailsDto>> CreateListAsync(ListCreateDto listCreateDto);
        Task<IResult> UpdateListAsync(ListUpdateDto listUpdateDto);
        Task<IResult> DeleteListAsync(Guid id);
        Task<IEnumerable<ListDetailsDto>> GetAllListsAsync();
        Task<IDataResult<ListDetailsDto>> GetListByIdAsync(Guid id);
    }

}
