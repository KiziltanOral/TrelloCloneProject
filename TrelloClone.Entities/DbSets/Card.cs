using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrelloClone.Core.Entities.Base;

namespace TrelloClone.Entities.DbSets
{
    public class Card : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid ListId { get; set; }
        public List List { get; set; }
    }
}
