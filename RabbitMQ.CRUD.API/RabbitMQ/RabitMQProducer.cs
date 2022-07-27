using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace RabbitMQ.CRUD.API.RabbitMQ
{
    public class RabitMQProducer : IRabitMQProducer
    {
        public void SendProductMessage<T>(T message)
        {
            //Define the Rabbit MQ Docker Image Server.
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            //Define the Connection String of the RabbitMQ Using Connection Factory
            var connection = factory.CreateConnection();

            //Define a channel with session and model
            using var channel = connection.CreateModel();

            //Define the queue
            channel.QueueDeclare("product", exclusive: false);

            //Serialize the message
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            //Add the data to the product queue
            channel.BasicPublish(exchange: "", routingKey: "product", body: body);
        }
    }
}
