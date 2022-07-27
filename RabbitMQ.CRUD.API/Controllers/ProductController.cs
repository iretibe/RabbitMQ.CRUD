using Microsoft.AspNetCore.Mvc;
using RabbitMQ.CRUD.API.Entities;
using RabbitMQ.CRUD.API.RabbitMQ;
using RabbitMQ.CRUD.API.Services;

namespace RabbitMQ.CRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IRabitMQProducer _rabitMQProducer;

        public ProductController(IProductService productService, IRabitMQProducer rabitMQProducer)
        {
            this.productService = productService;
            _rabitMQProducer = rabitMQProducer;
        }

        [HttpGet("GetAllProducts")]
        public IEnumerable<Product> GetAllProducts()
        {
            var productList = productService.GetProductList();

            return productList;
        }

        [HttpGet("GetProductById")]
        public Product GetProductById(int Id)
        {
            return productService.GetProductById(Id);
        }

        [HttpPost("PostProduct")]
        public Product PostProduct(Product product)
        {
            var productData = productService.AddProduct(product);

            //Send the inserted product data to the queue and consumer will listen to this data from queue
            _rabitMQProducer.SendProductMessage(productData);

            return productData;
        }

        [HttpPut("PutProduct")]
        public Product PutProduct(Product product)
        {
            return productService.UpdateProduct(product);
        }

        [HttpDelete("DeleteProduct")]
        public bool DeleteProduct(int Id)
        {
            return productService.DeleteProduct(Id);
        }
    }
}
