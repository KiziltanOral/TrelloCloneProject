using TrelloClone.Core.Results.Interfaces;
using TrelloClone.Dtos.BoardDtos;

namespace TrelloClone.Business.Interfaces
{
    public interface IBoardService
    {
        Task<IDataResult<BoardDetailsDto>> CreateBoardAsync(BoardCreateDto boardCreateDto);
        Task<IResult> UpdateBoardAsync(BoardUpdateDto boardUpdateDto);
        Task<IResult> DeleteBoardAsync(Guid id);
        Task<IDataResult<IEnumerable<BoardDetailsDto>>> GetAllBoardsAsync();
        Task<IDataResult<BoardDetailsDto>> GetBoardByIdAsync(Guid id);
    }
}
