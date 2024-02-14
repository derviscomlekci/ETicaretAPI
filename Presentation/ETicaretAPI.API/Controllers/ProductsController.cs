using ETicaretAPI.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly ICustomerWriteRepository _customerWriteRepository;



        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IOrderWriteRepository orderWriteRepository, ICustomerWriteRepository customerWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
        }

        [HttpGet]
        public async Task Get() 
        {
            var customerId=Guid.NewGuid();
            await _customerWriteRepository.AddAsync(new() { Id = customerId, Name = "Dervo" });
            await _orderWriteRepository.AddAsync(new() { Address = "İzmir", Description = "hizli gelsin",CustomerId=customerId});
            await _orderWriteRepository.AddAsync(new() { Address = "Anakra", Description = "ayvas gel",CustomerId=customerId});
            await _orderWriteRepository.SaveAsync();
        }

    }
}
