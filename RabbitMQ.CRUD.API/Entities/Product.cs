namespace RabbitMQ.CRUD.API.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int StockLevel { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
