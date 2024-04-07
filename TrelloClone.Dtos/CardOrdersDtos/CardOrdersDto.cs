using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloClone.Dtos.CardOrdersDtos
{
    public class CardOrdersDto
    {
        public Guid Id { get; set; }
        public int Index { get; set; }
        public Guid CardId { get; set; }
        public Guid ListId { get; set; }
    }
}
