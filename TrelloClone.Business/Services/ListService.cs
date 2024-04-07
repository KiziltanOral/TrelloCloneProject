using AutoMapper;
using TrelloClone.Business.Interfaces;
using TrelloClone.Core.Results.Concrete;
using TrelloClone.Core.Results.Interfaces;
using TrelloClone.DataAccess.Interfaces.Repositories;
using TrelloClone.Dtos.ListDtos;
using TrelloClone.Entities.DbSets;

namespace TrelloClone.Business.Services
{
    public class ListService : IListService
    {
        private readonly IListRepository _listRepository;
        private readonly IMapper _mapper;
        private readonly ICardOrdersRepository _cardOrdersRepository;
        private readonly ICardRepository _cardRepository;

        public ListService(IListRepository listRepository, IMapper mapper, ICardOrdersRepository cardOrdersRepository, ICardRepository cardRepository)
        {
            _listRepository = listRepository;
            _mapper = mapper;
            _cardOrdersRepository = cardOrdersRepository;
            _cardRepository = cardRepository;
        }

        public async Task<IDataResult<ListDto>> CreateListAsync(ListCreateDto createListDto)
        {
            var list = _mapper.Map<List>(createListDto);
            var entity = await _listRepository.AddAsync(list);

            var listDto = _mapper.Map<ListDto>(entity);
            return new SuccessDataResult<ListDto>(listDto, "List successfully created.");
        }

        public async Task<IResult> UpdateListAsync(ListUpdateDto updateListDto)
        {
            var list = await _listRepository.GetByIdAsync(updateListDto.Id);
            if (list == null)
            {
                return new ErrorResult("List not found.");
            }

            _mapper.Map(updateListDto, list);
            await _listRepository.UpdateAsync(list);
            return new SuccessResult("List successfully updated.");
        }

        public async Task<IResult> DeleteListAsync(Guid listId)
        {
            var list = await _listRepository.GetByIdAsync(listId);
            if (list == null)
            {
                return new ErrorResult("List not found.");
            }

            var cardOrders = await _cardOrdersRepository.GetAllAsync(co => co.ListId == listId);
            if (cardOrders.Any())
            {
                await _cardOrdersRepository.DeleteRangeAsync(cardOrders);
            }
            await _listRepository.DeleteAsync(list);
            return new SuccessResult("List successfully deleted.");
        }

        public async Task<IDataResult<ListDto>> GetListByIdAsync(Guid listId)
        {
            var list = await _listRepository.GetByIdWithCardsAsync(listId);
            if (list == null)
            {
                return new ErrorDataResult<ListDto>("List not found.");
            }

            var listDto = _mapper.Map<ListDto>(list);
            return new SuccessDataResult<ListDto>(listDto, "List details successfully listed.");
        }

        public async Task<IDataResult<List<ListDto>>> GetAllListsAsync()
        {
            var lists = await _listRepository.GetAllListsWithCardsAsync();
            var listDtos = _mapper.Map<List<ListDto>>(lists);
            return new SuccessDataResult<List<ListDto>>(listDtos, "Lists successfully listed.");
        }
    }
}
