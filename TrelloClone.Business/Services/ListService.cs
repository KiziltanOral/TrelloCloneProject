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

        public ListService(IListRepository listRepository, IMapper mapper)
        {
            _listRepository = listRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<ListDetailsDto>> CreateListAsync(ListCreateDto listCreateDto)
        {
            var listEntity = _mapper.Map<List>(listCreateDto);
            await _listRepository.AddAsync(listEntity);
            await _listRepository.SaveChangesAsync();
            var listDetailsDto = _mapper.Map<ListDetailsDto>(listEntity);
            return new SuccessDataResult<ListDetailsDto>(listDetailsDto, "List successfully created.");
        }

        public async Task<IResult> UpdateListAsync(ListUpdateDto listUpdateDto)
        {
            var listEntity = await _listRepository.GetByIdAsync(listUpdateDto.Id);
            if (listEntity == null)
            {
                return new ErrorResult("List not found.");
            }
            _mapper.Map(listUpdateDto, listEntity);
            await _listRepository.SaveChangesAsync();
            return new SuccessResult("List successfully updated.");
        }

        public async Task<IResult> DeleteListAsync(Guid id)
        {
            var listEntity = await _listRepository.GetByIdAsync(id);
            if (listEntity == null)
            {
                return new ErrorResult("List not found.");
            }
            await _listRepository.DeleteAsync(listEntity);
            await _listRepository.SaveChangesAsync();
            return new SuccessResult("List successfully deleted.");
        }

        public async Task<IDataResult<IEnumerable<ListDetailsDto>>> GetAllListsAsync()
        {
            var lists = await _listRepository.GetAllAsync();
            var listDetailsDtos = _mapper.Map<IEnumerable<ListDetailsDto>>(lists);
            return new SuccessDataResult<IEnumerable<ListDetailsDto>>(listDetailsDtos, "Lists successfully retrieved.");
        }

        public async Task<IDataResult<ListDetailsDto>> GetListByIdAsync(Guid id)
        {
            var list = await _listRepository.GetByIdAsync(id);
            if (list == null)
            {
                return new ErrorDataResult<ListDetailsDto>("List not found.");
            }
            var listDetailsDto = _mapper.Map<ListDetailsDto>(list);
            return new SuccessDataResult<ListDetailsDto>(listDetailsDto, "List successfully retrieved.");
        }
    }
}
