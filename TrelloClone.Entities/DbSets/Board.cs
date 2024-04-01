using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrelloClone.Core.Entities.Base;

namespace TrelloClone.Entities.DbSets
{
    public class Board : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<List> Lists { get; set; } = new List<List>();
    }
}
