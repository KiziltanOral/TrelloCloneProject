using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrelloClone.Dtos.CardDtos;

namespace TrelloClone.Dtos.ListDtos
{
    public class ListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<CardDto>? Cards { get; set; } = new List<CardDto>();
    }
}
