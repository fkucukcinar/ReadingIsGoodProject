using AutoMapper;
using BookStore.Api.DTO;
using BookStore.Api.Enums;
using BookStore.Api.Validators;
using BookStore.Core.Models;
using BookStore.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IOrderDetailService orderDetailService, IBookService bookService, IMapper mapper)
        {
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _bookService = bookService;
            _mapper = mapper;

        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrders(int customerId)
        {
            var orders = await _orderService.GetOrders(customerId);
            var musicResources = _mapper.Map<Order, OrderDTO>(orders);
            return Ok(musicResources);
        }
       
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> CreateOrder(OrderDTO newOrder) 
        {
            var validator = new SaveOrderValidator();
            var validationResult = await validator.ValidateAsync(newOrder);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var orderToCreate = _mapper.Map<OrderDTO, Order>(newOrder);
            var createdOrder = await _orderService.CreateOrder(orderToCreate);
            var order = await _orderService.GetOrderById(createdOrder.Id);
            var orderResource = _mapper.Map<Order, OrderDTO>(order);

            foreach (var item in newOrder.OrderDetails)
            {
                var orderDetailToCreate = _mapper.Map<OrderDetailDTO, OrderDetail>(item);
                orderDetailToCreate.OrderId = orderResource.Id;
                await _orderDetailService.CreateOrderDetail(orderDetailToCreate);
                 // update book stock
                if (newOrder.StatusId == StatusType.Sold.GetHashCode())
                    await _bookService.UpdateBookStock(item.BookId, item.Amount);
                else if (newOrder.StatusId == StatusType.Cancelled.GetHashCode())
                    await _bookService.UpdateBookStock(item.BookId, -1 * item.Amount);
            }

            

            return Ok(orderResource);
        }

    }
}
