using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrelloClone.Core.Entities.Interfaces;

namespace TrelloClone.Core.Entities.Base
{
    public class AuditableEntity : BaseEntity, ISoftDeleteableEntity
    {
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
