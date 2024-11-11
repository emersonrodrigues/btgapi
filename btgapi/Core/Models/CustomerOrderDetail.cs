// BTG.Core/Models/CustomerOrderDetail.cs
namespace BTG.Core.Models
{
    public class CustomerOrderDetail
    {
        public long OrderId { get; set; }
        public List<OrderItem> Items { get; set; } = new();
    }
}
