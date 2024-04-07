using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloClone.Dtos.CardOrdersDtos
{
    public class CardOrdersCreateDto
    {
        public Guid CardId { get; set; }
        public Guid ListId { get; set; }
        public int Index { get; set; }
    }
}
