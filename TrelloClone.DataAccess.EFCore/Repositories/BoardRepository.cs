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
    public class BoardRepository : EFBaseRepository<Board>, IBoardRepository
    {
        public BoardRepository(TrelloCloneDbContext context) : base(context)
        {            
        }
    }
}
