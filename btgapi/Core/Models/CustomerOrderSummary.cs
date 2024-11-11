// BTG.Core/Models/CustomerOrderSummary.cs
namespace BTG.Core.Models
{
    public class CustomerOrderSummary
    {
        public int TotalOrders { get; set; }
        public List<Order> Orders { get; set; } = new();
    }
}
