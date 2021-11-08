using AutoMapper;
using BookStore.Api.DTO;
using BookStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Api.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Customer, CustomerDTO>();
            CreateMap<Book, BookDTO>();
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDetail, OrderDetailDTO>();

            // Resource to Domain
            CreateMap<CustomerDTO, Customer>();
            CreateMap<BookDTO, Book>();
            CreateMap<OrderDTO, Order>();
            CreateMap<OrderDetailDTO, OrderDetail>();

        }
    }
}
