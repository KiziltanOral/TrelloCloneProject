using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrelloClone.Core.DataAccess.Interfaces;
using TrelloClone.Entities.DbSets;

namespace TrelloClone.DataAccess.Interfaces.Repositories
{
    public interface ICardOrdersRepository : IAsyncRepository, IAsyncInsertableRepository<CardOrders>, IAsyncQueryableRepository<CardOrders>, IAsyncDeleteableRepository<CardOrders>, IAsyncFindableRepository<CardOrders>, IAsyncUpdateableRepository<CardOrders>
    {
    }
}
