using TrelloClone.Core.DataAccess.Interfaces;
using TrelloClone.Entities.DbSets;

namespace TrelloClone.DataAccess.Interfaces.Repositories
{
    public interface ICardRepository : IAsyncRepository, IAsyncInsertableRepository<Card>, IAsyncQueryableRepository<Card>, IAsyncDeleteableRepository<Card>, IAsyncFindableRepository<Card>, IAsyncUpdateableRepository<Card>
    {
    }
}
