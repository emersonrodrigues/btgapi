// BTG.Infrastructure/Interfaces/IOrderRepository.cs
using BTG.Core.Models;

namespace BTG.Infrastructure.Interfaces
{
    public interface IOrderRepository
    {
        /// <summary>
        /// Busca um pedido específico pelo seu ID, incluindo os itens do pedido.
        /// </summary>
        Task<Order> GetOrderByIdAsync(long id);
    }
}
