using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrelloClone.Core.Entities.Base;

namespace TrelloClone.Entities.DbSets
{
    public class List : BaseEntity
    {
        public string Name { get; set; }
        public int OrderIndex { get; set; }
        public ICollection<Card> Cards { get; set; } = new List<Card>();
    }
}
