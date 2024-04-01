using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrelloClone.Core.Entities.Base;

namespace TrelloClone.Core.DataAccess.Interfaces
{
    public interface IAsyncUpdateableRepository<TEntity> : IAsyncRepository where TEntity : BaseEntity
    {
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
