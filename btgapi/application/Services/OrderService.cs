// BTG.Application/Services/OrderService.cs
using BTG.Application.Interfaces;
using BTG.Core.Models;
using BTG.Infrastructure.Interfaces;

namespace BTG.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Order> GetOrderAsync(long id) => await _repository.GetOrderByIdAsync(id);
    }
}
