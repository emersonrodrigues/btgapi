// BTG.Application/Interfaces/IOrderService.cs
using BTG.Core.Models;

namespace BTG.Application.Interfaces
{
    public interface IOrderService
    {
        /// <summary>
        /// Obtém os detalhes de um pedido por ID.
        /// </summary>
        Task<Order> GetOrderAsync(long id);
    }
}
