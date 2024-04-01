using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloClone.Core.DataAccess.Interfaces
{
    public interface IDeleteableRepository<TEntity> : IRepository
    {
        bool Delete(TEntity entity);
    }
}
