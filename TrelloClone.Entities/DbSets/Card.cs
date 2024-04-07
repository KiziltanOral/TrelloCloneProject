using TrelloClone.Core.Entities.Base;

namespace TrelloClone.Entities.DbSets
{
    public class Card : BaseEntity
    {
        public string Title { get; set; }
        public Guid CardOrderId { get; set; }
        public CardOrders CardOrder { get; set; }        
    }
}
