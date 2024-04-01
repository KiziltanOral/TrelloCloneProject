using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloClone.Core.Entities.Interfaces
{
    public interface ISoftDeleteableEntity : ICreateableEntity, IUpdateableEntity, IEntity
    {
        string? DeletedBy { get; set; }
        DateTime? DeletedDate { get; set; }
    }
}
