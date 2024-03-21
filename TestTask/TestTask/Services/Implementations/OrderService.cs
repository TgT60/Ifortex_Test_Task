using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Order> GetOrder()
        {
            return Task.FromResult(_dbContext.Orders
                .OrderByDescending(order => order.Price * order.Quantity)
                .FirstOrDefault());
        }

        public Task<List<Order>> GetOrders()
        {
            return _dbContext.Orders.Where(order => order.Quantity > 10).ToListAsync();
        }
    }
}
