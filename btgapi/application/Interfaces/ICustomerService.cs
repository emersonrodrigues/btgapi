// BTG.Application/Interfaces/ICustomerService.cs
using BTG.Core.Models;

namespace BTG.Application.Interfaces
{
    public interface ICustomerService
    {
        /// <summary>
        /// Obtém um resumo dos pedidos de um cliente, incluindo a quantidade total de pedidos.
        /// </summary>
        Task<CustomerOrderSummary> GetCustomerOrdersAsync(int customerId);
    }
}
