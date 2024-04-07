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
    public class CardRepository : EFBaseRepository<Card>, ICardRepository
    {
        private readonly TrelloCloneDbContext _context;

        public CardRepository(TrelloCloneDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Card>> GetAllCardsWithOrdersAsync()
        {
            return await _context.Cards.Include(c => c.CardOrder).ToListAsync();
        }
    }
}
