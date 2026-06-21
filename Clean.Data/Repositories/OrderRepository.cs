using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean.Core.Entities;
using Clean.Core.Repositories;

namespace Clean.Data.Repositories
{
    public class OrderRepository: IOrderRepository
    {
        private readonly DataContext _dataContext;

        public OrderRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Order> GetAll()
        {
            return _dataContext.orders.ToList();
        }

        public Order GetById(int id)
        {
            return _dataContext.orders.Find(id);
        }
        public async Task postAsync(Order order)
        {
            _dataContext.orders.Add(order);
            await _dataContext.SaveChangesAsync();
        }
        public async Task putAsync(int id, Order order)
        {
            Order o = _dataContext.orders.Find(id);
            if (o != null)
            {
                o.id = id;
                o.client = order.client;
                o.recipes = order.recipes;
                o.deliveryDate = order.deliveryDate;
                await _dataContext.SaveChangesAsync();
            }
        }
        public async Task deleteAsync(int id)
        {
            Order o = _dataContext.orders.Find(id);
            if (o != null)
            {
                _dataContext.orders.Remove(o);
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
