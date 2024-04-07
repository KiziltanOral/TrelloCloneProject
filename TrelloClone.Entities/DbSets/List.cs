using TrelloClone.Core.Entities.Base;

namespace TrelloClone.Entities.DbSets
{
    public class List : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<CardOrders> CardOrders { get; set; } = new List<CardOrders>();
    }
}
