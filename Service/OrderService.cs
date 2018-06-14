using Domain.Entities;
using Domain.Interface;
using Infrastructure.Data;
using Service_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    class OrderService : IOrderService
    {
        private IRepository<Order> orderRepository;
        public OrderService()
        {
            this.orderRepository = new Repository<Order>();
        }
        public Order GetOrder(int id)
        {
            return orderRepository.Get(id);
        }
    }
}
