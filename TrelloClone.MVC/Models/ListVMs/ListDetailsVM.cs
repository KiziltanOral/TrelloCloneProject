using TrelloClone.Dtos.CardDtos;
using TrelloClone.MVC.Models.CardVMs;

namespace TrelloClone.MVC.Models.ListVMs
{
    public class ListDetailsVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<CardDetailsVM>? Cards { get; set; } = new List<CardDetailsVM>();
    }
}
