using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloClone.Dtos.ListDtos
{
    public class ListUpdateDto
    {
        public Guid Id { get; set; }    
        public string Name { get; set; }
    }
}
