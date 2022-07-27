using Microsoft.EntityFrameworkCore;
using RabbitMQ.CRUD.API.Entities;

namespace RabbitMQ.CRUD.API.Data
{
    public class RabbitMQCRUDContext : DbContext
    {
        public RabbitMQCRUDContext(DbContextOptions<RabbitMQCRUDContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
