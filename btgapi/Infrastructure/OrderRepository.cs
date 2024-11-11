// BTG.Infrastructure/Data/OrderRepository.cs
using Dapper;
using BTG.Core.Models;
using BTG.Infrastructure.Interfaces;

namespace BTG.Infrastructure.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DapperContext _context;

        public OrderRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<Order> GetOrderByIdAsync(long id)
        {
            var query = @"
                SELECT id, customer_id AS CustomerId 
                FROM orders 
                WHERE id = @Id;

                SELECT id, order_id AS OrderId, product_id AS ProductId, amount, price 
                FROM orderitems 
                WHERE order_id = @Id;";
            
            using (var connection = _context.CreateConnection())
            {
                using (var multi = await connection.QueryMultipleAsync(query, new { Id = id }))
                {
                    var order = await multi.ReadFirstOrDefaultAsync<Order>();
                    if (order != null)
                    {
                        order.Items = (await multi.ReadAsync<OrderItem>()).ToList();
                    }
                    return order;
                }
            }
        }
    }
}
