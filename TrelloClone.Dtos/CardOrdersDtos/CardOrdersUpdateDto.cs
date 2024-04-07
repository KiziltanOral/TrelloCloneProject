using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloClone.Dtos.CardOrdersDtos
{
    public class CardOrdersUpdateDto
    {
        public Guid Id { get; set; }
        public int NewIndex { get; set; }
    }
}
