// BTG.Core/Models/Order.cs
namespace BTG.Core.Models
{
    public class Order
    {
        public long Id { get; set; }
        public int CustomerId { get; set; }
        public List<OrderItem> Items { get; set; } = new();
    }
}
