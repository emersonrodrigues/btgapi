// BTG.Core/Models/OrderItem.cs
namespace BTG.Core.Models
{
    public class OrderItem
    {
        public long Id { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
    }
}
