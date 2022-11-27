using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RiseTech.Consumer.Models;
using RiseTech.Data;
using RiseTech.Data.Entities;
using RiseTech.Data.Repositories;
using RiseTech.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace RiseTech.Consumer
{
    internal class Program
    {
        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.SetBasePath(Directory.GetCurrentDirectory());
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddDbContext<PhoneBookContext>(
                        options => options.UseNpgsql("Server=localhost;Port=5432;Database=ContactDb;User Id=postgres;Password=@Password@;"));
                    services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
                });

            return hostBuilder;
        }

        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var repositoryWrapper = host.Services.GetService<IRepositoryWrapper>();

            var factory = new ConnectionFactory();
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare("ReportRequestQueue", false, false, false, null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, args) =>
            {
                var body = args.Body.ToArray();
                var jsonString = Encoding.UTF8.GetString(body);
                Console.WriteLine($"Recevied Json: {jsonString}");

                ReportRequestModel reportRequestModel = JsonConvert.DeserializeObject<ReportRequestModel>(jsonString);
                Report report = repositoryWrapper.Reports.GetReportById(reportRequestModel.ReportId);
                ReportDetail reportDetail = new ReportDetail()
                {
                    Location = reportRequestModel.Location,
                    PersonCount = repositoryWrapper.Infos.GetAllInfo().Where(i => i.Location == reportRequestModel.Location).Select(i => i.PersonId).Distinct().Count(),
                    TelephoneCount = repositoryWrapper.Infos.GetAllInfo().Where(i => i.Location == reportRequestModel.Location && !string.IsNullOrEmpty(i.Telephone)).Count()
                };
                string detail = JsonConvert.SerializeObject(reportDetail);
                report.Detail = detail;
                report.Status = ReportStatus.Ready;
                repositoryWrapper.Reports.UpdateReport(report);
                repositoryWrapper.Save();

                Console.WriteLine($"(ReportId:{report.Id}) Ready. {JsonConvert.SerializeObject(reportDetail)} ");
            };

            channel.BasicConsume("ReportRequestQueue", true, consumer);

            Console.ReadLine();
        }
    }
}
