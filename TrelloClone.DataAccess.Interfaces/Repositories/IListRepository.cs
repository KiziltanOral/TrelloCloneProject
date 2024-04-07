using TrelloClone.Core.DataAccess.Interfaces;
using TrelloClone.Entities.DbSets;

namespace TrelloClone.DataAccess.Interfaces.Repositories
{
    public interface IListRepository : IAsyncRepository, IAsyncInsertableRepository<List>, IAsyncQueryableRepository<List>, IAsyncDeleteableRepository<List>, IAsyncFindableRepository<List>, IAsyncUpdateableRepository<List>
    {
        Task<IEnumerable<List>> GetAllListsWithCardsAsync();
        Task<List>? GetByIdWithCardsAsync(Guid listId);
    }
}
