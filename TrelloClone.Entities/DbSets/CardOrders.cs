using TrelloClone.Core.Entities.Base;

namespace TrelloClone.Entities.DbSets
{
    public class CardOrders : BaseEntity
    {
        public int Index { get; set; }
        public Guid CardId { get; set; }
        public Card Card { get; set; }
        public Guid ListId { get; set; }
        public List List { get; set; }
    }
}
