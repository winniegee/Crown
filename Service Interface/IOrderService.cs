using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Interface
{
    public interface IOrderService
    {
        Order GetOrder(int id);
    }
}
