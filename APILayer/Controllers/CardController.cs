using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrelloClone.Business.Interfaces;
using TrelloClone.Dtos.CardDtos;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCard([FromBody] CardCreateDto cardCreateDto)
        {
            var result = await _cardService.CreateCardAsync(cardCreateDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            
            return CreatedAtAction(nameof(GetCardById), new { id = result.Data.Id }, result.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCardById(Guid id)
        {
            var result = await _cardService.GetCardByIdAsync(id);
            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }
            return Ok(result.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCard(Guid id, [FromBody] CardUpdateDto cardUpdateDto)
        {
            if (id != cardUpdateDto.Id)
            {
                return BadRequest("Id in the URL does not match the Id in the body");
            }
            var result = await _cardService.UpdateCardAsync(cardUpdateDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCard(Guid id)
        {
            var result = await _cardService.DeleteCardAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCards()
        {
            var result = await _cardService.GetAllCardsAsync();
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("{cardId}/MoveWithinList/{targetIndex}")]
        public async Task<IActionResult> MoveCardWithinList(Guid cardId, int targetIndex)
        {
            var result = await _cardService.MoveCardWithinListAsync(cardId, targetIndex);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("{cardId}/MoveToAnotherList/{targetListId}/{targetIndex}")]
        public async Task<IActionResult> MoveCardToAnotherList(Guid cardId, Guid targetListId, int targetIndex)
        {
            var result = await _cardService.MoveCardToAnotherListAsync(cardId, targetListId, targetIndex);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
