using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Api.DTO
{
    public class OrderDetailDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public OrderDTO Order { get; set; }
        public int BookId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
    }
}
