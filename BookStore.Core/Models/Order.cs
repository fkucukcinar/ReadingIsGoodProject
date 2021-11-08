using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Models
{
    public class Order
    {
        public Order()
        {
            OrderDetails = new Collection<OrderDetail>();
        }
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int StatusId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
    
}
