﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TrelloClone.Core.Entities.Base;

namespace TrelloClone.Core.DataAccess.Interfaces
{
    public interface IAsyncOrderableRepository<TEntity> : IAsyncQueryableRepository<TEntity>, IAsyncRepository where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, TKey>> orderby, bool orderDesc = false, bool tracking = true);
        Task<IEnumerable<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, TKey>> orderby, bool orderDesc = false, bool tracking = true);
    }
}
