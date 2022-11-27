using RiseTech.Services.RabbitMQ.Models;

namespace RiseTech.Services.RabbitMQ.Interface
{
    public interface IRabbitMQClient
    {
        public void AddReportRequestToQueue(ReportRequestModel reportRequestModel);
    }
}
