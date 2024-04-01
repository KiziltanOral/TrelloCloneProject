using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrelloClone.Business.Interfaces;
using TrelloClone.Dtos.BoardDtos;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly IBoardService _boardService;

        public BoardController(IBoardService boardService)
        {
            _boardService = boardService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBoard([FromBody] BoardCreateDto boardCreateDto)
        {
            var result = await _boardService.CreateBoardAsync(boardCreateDto);
            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBoard(Guid id, [FromBody] BoardUpdateDto boardUpdateDto)
        {
            if (id != boardUpdateDto.Id)
            {
                return BadRequest("Id in the URL does not match the Id in the body");
            }
            var result = await _boardService.UpdateBoardAsync(boardUpdateDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoard(Guid id)
        {
            var result = await _boardService.DeleteBoardAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBoards()
        {
            var result = await _boardService.GetAllBoardsAsync();
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBoardById(Guid id)
        {
            var result = await _boardService.GetBoardByIdAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
