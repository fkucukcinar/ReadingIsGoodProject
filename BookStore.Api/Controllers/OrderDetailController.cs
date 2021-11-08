using AutoMapper;
using BookStore.Api.DTO;
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
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;
        private readonly IMapper _mapper;
        public OrderDetailController(IOrderDetailService orderDetailService, IMapper mapper)
        {
            _orderDetailService = orderDetailService;
            _mapper = mapper;
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<IEnumerable<OrderDetailDTO>>> GetOrderDetails(int orderId)
        {
            var orderDetails = await _orderDetailService.GetOrderDetails(orderId);
            return Ok(orderDetails);
        }
    }

    
}

