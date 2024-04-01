using AutoMapper;
using TrelloClone.Business.Interfaces;
using TrelloClone.Core.Results.Concrete;
using TrelloClone.Core.Results.Interfaces;
using TrelloClone.DataAccess.Interfaces.Repositories;
using TrelloClone.Dtos.BoardDtos;
using TrelloClone.Entities.DbSets;

namespace TrelloClone.Business.Services
{
    public class BoardService : IBoardService
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IMapper _mapper;

        public BoardService(IBoardRepository boardRepository, IMapper mapper)
        {
            _boardRepository = boardRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<BoardDetailsDto>> CreateBoardAsync(BoardCreateDto boardCreateDto)
        {
            var boardEntity = _mapper.Map<Board>(boardCreateDto);
            await _boardRepository.AddAsync(boardEntity);
            await _boardRepository.SaveChangesAsync();
            var boardDetailsDto = _mapper.Map<BoardDetailsDto>(boardEntity);
            return new SuccessDataResult<BoardDetailsDto>(boardDetailsDto, "Board successfully created.");
        }

        public async Task<IResult> UpdateBoardAsync(BoardUpdateDto boardUpdateDto)
        {
            var boardEntity = await _boardRepository.GetByIdAsync(boardUpdateDto.Id);
            if (boardEntity == null)
            {
                return new ErrorResult("Board not found.");
            }

            _mapper.Map(boardUpdateDto, boardEntity);
            await _boardRepository.SaveChangesAsync();
            return new SuccessResult("Board successfully updated.");
        }

        public async Task<IResult> DeleteBoardAsync(Guid id)
        {
            var boardEntity = await _boardRepository.GetByIdAsync(id);
            if (boardEntity == null)
            {
                return new ErrorResult("Board not found.");
            }

            await _boardRepository.DeleteAsync(boardEntity);
            await _boardRepository.SaveChangesAsync();
            return new SuccessResult("Board successfully deleted.");
        }

        public async Task<IDataResult<IEnumerable<BoardDetailsDto>>> GetAllBoardsAsync()
        {
            var boards = await _boardRepository.GetAllAsync();
            var boardDetailsDtos = _mapper.Map<IEnumerable<BoardDetailsDto>>(boards);
            return new SuccessDataResult<IEnumerable<BoardDetailsDto>>(boardDetailsDtos, "Boards successfully retrieved.");
        }

        public async Task<IDataResult<BoardDetailsDto>> GetBoardByIdAsync(Guid id)
        {
            var board = await _boardRepository.GetByIdAsync(id);
            if (board == null)
            {
                return new ErrorDataResult<BoardDetailsDto>("Board not found.");
            }

            var boardDetailsDto = _mapper.Map<BoardDetailsDto>(board);
            return new SuccessDataResult<BoardDetailsDto>(boardDetailsDto, "Board successfully retrieved.");
        }
    }
}
