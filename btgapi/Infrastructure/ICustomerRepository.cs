// BTG.Infrastructure/Interfaces/ICustomerRepository.cs
using BTG.Core.Models;

namespace BTG.Infrastructure.Interfaces
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// Retorna um resumo dos pedidos de um cliente, incluindo o total de pedidos.
        /// </summary>
        Task<CustomerOrderSummary> GetCustomerOrderSummaryAsync(int customerId);
    }
}
