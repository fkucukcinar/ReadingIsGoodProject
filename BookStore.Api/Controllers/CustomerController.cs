using AutoMapper;
using BookStore.Api.DTO;
using BookStore.Api.Validators;
using BookStore.Core.Models;
using BookStore.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using BookStore.Api.IdentityAuth;
using System;

namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<ICustomerService> _logger;
        public CustomerController(ICustomerService customerService, IMapper mapper, ILogger<ICustomerService> logger, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _customerService = customerService;
            _mapper = mapper;
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<CustomerDTO>> CreateCustomer([FromBody] CustomerDTO  newCustomer)
        {
            _logger.LogInformation("CreateCustomer started: ");
            var validator = new SaveCustomerValidator();
            var validationResult = await validator.ValidateAsync(newCustomer);
            if (!validationResult.IsValid)
            {
                _logger.LogError("CreateCustomer validation errors: " + validationResult.Errors);
                return BadRequest(validationResult.Errors);
            }

            var userExists = await _userManager.FindByNameAsync(newCustomer.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            ApplicationUser user = new ApplicationUser()
            {
                Email = newCustomer.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = newCustomer.Username
            };
            var result = await _userManager.CreateAsync(user, newCustomer.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            var customerToCreate = _mapper.Map<CustomerDTO, Customer>(newCustomer);
            var createdCustomer = await _customerService.CreateCustomer(customerToCreate);
            var customer = await _customerService.GetCustomerById(createdCustomer.Id);
            var customerResource = _mapper.Map<Customer, CustomerDTO>(customer);
            
            _logger.LogInformation("CreateCustomer success");
            return Ok(customerResource);
            
        }
        
        

    }
}
