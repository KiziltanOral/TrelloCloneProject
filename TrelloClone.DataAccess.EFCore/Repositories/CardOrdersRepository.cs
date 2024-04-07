using TrelloClone.Core.DataAccess.EntityFramework;
using TrelloClone.DataAccess.Context;
using TrelloClone.DataAccess.Interfaces.Repositories;
using TrelloClone.Entities.DbSets;

namespace TrelloClone.DataAccess.EFCore.Repositories
{
    public class CardOrdersRepository : EFBaseRepository<CardOrders>, ICardOrdersRepository
    {
        public CardOrdersRepository(TrelloCloneDbContext context) : base(context)
        {
        }  
    }
}
