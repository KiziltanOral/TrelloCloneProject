using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrelloClone.Core.DataAccess.EntityFramework;
using TrelloClone.DataAccess.Context;
using TrelloClone.DataAccess.Interfaces.Repositories;
using TrelloClone.Entities.DbSets;

namespace TrelloClone.DataAccess.EFCore.Repositories
{
    public class ListRepository : EFBaseRepository<List>, IListRepository
    {
        private readonly TrelloCloneDbContext _context;

        public ListRepository(TrelloCloneDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<List>> GetAllListsWithCardsAsync()
        {
            return await _context.Lists.Include(l => l.CardOrders).ThenInclude(co => co.Card).ToListAsync();
        }

        public async Task<List?> GetByIdWithCardsAsync(Guid listId)
        {
            return await _context.Lists.Include(l => l.CardOrders).ThenInclude(co => co.Card).FirstOrDefaultAsync(l => l.Id == listId);
        }
    }
}
