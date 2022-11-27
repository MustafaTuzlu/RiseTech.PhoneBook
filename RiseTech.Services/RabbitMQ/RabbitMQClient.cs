using RabbitMQ.Client;
using RiseTech.Services.RabbitMQ.Interface;
using System.Text.Json;
using System.Text;
using RiseTech.Services.RabbitMQ.Models;

namespace RiseTech.Services.RabbitMQ
{
    public class RabbitMQClient : IRabbitMQClient
    {
        private readonly IConnectionFactory factory;
        private readonly IConnection connection;

        public RabbitMQClient()
        {
            this.factory = new ConnectionFactory();
            connection = factory.CreateConnection();
        }

        public void AddReportRequestToQueue(ReportRequestModel reportRequestModel)
        {
            using (var channel = this.connection.CreateModel())
            {
                channel.QueueDeclare(
                    queue: "ReportRequestQueue",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var jsonData = JsonSerializer.Serialize(reportRequestModel);
                var bodyData = Encoding.UTF8.GetBytes(jsonData);

                channel.BasicPublish(
                    exchange: "",
                    routingKey: "ReportRequestQueue",
                    basicProperties: null,
                    body: bodyData
                    );
            }
        }
    }
}
