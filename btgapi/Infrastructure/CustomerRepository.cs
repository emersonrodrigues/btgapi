// BTG.Infrastructure/Data/CustomerRepository.cs
using Dapper;
using BTG.Core.Models;
using BTG.Infrastructure.Interfaces;

namespace BTG.Infrastructure.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DapperContext _context;

        public CustomerRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<CustomerOrderSummary> GetCustomerOrderSummaryAsync(int customerId)
        {
            var queryOrders = @"
                SELECT id AS Id, customer_id AS CustomerId
                FROM orders 
                WHERE customer_id = @CustomerId;
            ";

            var queryOrderItems = @"
                SELECT id, order_id AS OrderId, product_id AS ProductId, amount, price 
                FROM orderitems 
                WHERE order_id = @OrderId;
            ";

            using (var connection = _context.CreateConnection())
            {
                // Buscar pedidos do cliente
                var orders = (await connection.QueryAsync<Order>(queryOrders, new { CustomerId = customerId })).ToList();

                if (orders.Any())
                {
                    foreach (var order in orders)
                    {
                        // Buscar itens para cada pedido
                        order.Items = (await connection.QueryAsync<OrderItem>(queryOrderItems, new { OrderId = order.Id })).ToList();
                    }
                }

                // Retornar o resumo com a quantidade total de pedidos e a lista de pedidos com seus itens
                return new CustomerOrderSummary
                {
                    TotalOrders = orders.Count,
                    Orders = orders
                };
            }
        }
    }
}

// // BTG.Infrastructure/Data/CustomerRepository.cs
// using Dapper;
// using BTG.Core.Models;
// using BTG.Infrastructure.Interfaces;

// namespace BTG.Infrastructure.Data
// {
//     public class CustomerRepository : ICustomerRepository
//     {
//         private readonly DapperContext _context;

//         public CustomerRepository(DapperContext context)
//         {
//             _context = context;
//         }

//         public async Task<CustomerOrderSummary> GetCustomerOrderSummaryAsync(int customerId)
//         {
//             var query = @"SELECT COUNT(*) as TotalOrders
//                           FROM orders WHERE customer_id = @CustomerId;
//                           SELECT id, customer_id AS CustomerId  FROM orders WHERE customer_id = @CustomerId;";

//             using (var connection = _context.CreateConnection())
//             {
//                 using (var multi = await connection.QueryMultipleAsync(query, new { CustomerId = customerId }))
//                 {
//                     var summary = new CustomerOrderSummary
//                     {
//                         TotalOrders = await multi.ReadFirstAsync<int>(),
//                         Orders = (await multi.ReadAsync<Order>()).ToList()
//                     };
//                     return summary;
//                 }
//             }
//         }
//     }
// }
