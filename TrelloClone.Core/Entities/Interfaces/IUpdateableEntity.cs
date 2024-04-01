using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloClone.Core.Entities.Interfaces
{
    public interface IUpdateableEntity : ICreateableEntity, IEntity
    {
        string? ModifiedBy { get; set; }
        DateTime? ModifiedDate { get; set; }
    }
}
