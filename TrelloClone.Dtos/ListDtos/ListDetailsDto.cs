using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrelloClone.Dtos.CardDtos;

namespace TrelloClone.Dtos.ListDtos
{
    public class ListDetailsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CardDetailsDto> Cards { get; set; }
    }
}
