using Microsoft.AspNetCore.Mvc;
using TrelloClone.Business.Interfaces;
using TrelloClone.Dtos.ListDtos;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly IListService _listService;

        public ListController(IListService listService)
        {
            _listService = listService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateList([FromBody] ListCreateDto listCreateDto)
        {
            var result = await _listService.CreateListAsync(listCreateDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateList(Guid id, [FromBody] ListUpdateDto listUpdateDto)
        {
            if (id != listUpdateDto.Id)
            {
                return BadRequest("Id in the URL does not match the Id in the body");
            }
            var result = await _listService.UpdateListAsync(listUpdateDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteList(Guid id)
        {
            var result = await _listService.DeleteListAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLists()
        {
            var result = await _listService.GetAllListsAsync();
            return Ok(result);
        }
    }
}

