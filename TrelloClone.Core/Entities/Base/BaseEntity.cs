using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrelloClone.Core.Entities.Interfaces;
using TrelloClone.Core.Enums;

namespace TrelloClone.Core.Entities.Base
{
    public abstract class BaseEntity : ICreateableEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Status Status { get; set; } = Status.Active;
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        
    }
}
