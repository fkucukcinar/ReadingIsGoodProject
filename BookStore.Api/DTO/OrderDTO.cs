using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Api.DTO
{
    public class OrderDTO
    {
        public OrderDTO()
        {
            OrderDetails = new Collection<OrderDetailDTO>();
        }
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int StatusId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public ICollection<OrderDetailDTO> OrderDetails { get; set; }
    }
}
