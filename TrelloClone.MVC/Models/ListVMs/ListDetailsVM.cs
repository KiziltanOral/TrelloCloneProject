using TrelloClone.Dtos.CardDtos;

namespace TrelloClone.MVC.Models.ListVMs
{
    public class ListDetailsVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CardDetailsDto>? Cards { get; set; }
    }
}
