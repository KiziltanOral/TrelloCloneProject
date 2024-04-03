using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloClone.Dtos.CardDtos
{
    public class CardUpdateDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid ListId { get; set; }
    }
}
