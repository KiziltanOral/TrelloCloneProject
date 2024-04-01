using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrelloClone.Dtos.ListDtos;

namespace TrelloClone.Dtos.BoardDtos
{
    public class BoardDetailsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<ListDetailsDto> Lists { get; set; }
    }

}
