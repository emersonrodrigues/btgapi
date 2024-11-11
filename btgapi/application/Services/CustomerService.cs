// BTG.Application/Services/CustomerService.cs
using BTG.Application.Interfaces;
using BTG.Core.Models;
using BTG.Infrastructure.Interfaces;

namespace BTG.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<CustomerOrderSummary> GetCustomerOrdersAsync(int customerId)
        {
            return await _repository.GetCustomerOrderSummaryAsync(customerId);
        }
    }
}
