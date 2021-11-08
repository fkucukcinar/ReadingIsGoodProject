using AutoMapper;
using BookStore.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        public BookController(IBookService bookService, IMapper mapper)
        {
            this._bookService = bookService;
            this._mapper = mapper;
        }
    }
}
