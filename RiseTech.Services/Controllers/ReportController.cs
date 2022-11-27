using Microsoft.AspNetCore.Mvc;
using RiseTech.Data.Entities;
using RiseTech.Data.Repositories.Interfaces;
using RiseTech.Services.RabbitMQ;
using RiseTech.Services.RabbitMQ.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiseTech.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private IRepositoryWrapper _repository;

        public ReportController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Report>>> GetReportsAsync()
        {
            try
            {
                IEnumerable<Report> reports = await _repository.Reports.GetAllReportsAsync();
                return await Task.FromResult(Ok(reports));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error Ex:" + ex.InnerException);
            }
        }

        [HttpPost]
        public ActionResult CreateReport(string loc)
        {
            try
            {
                Report report = new Report()
                {
                    Date = DateTime.Now,
                    Status = ReportStatus.Pending
                };
                _repository.Reports.CreateReport(report);
                _repository.Save();

                RabbitMQClient rabbitMqClient = new RabbitMQClient();
                rabbitMqClient.AddReportRequestToQueue(new ReportRequestModel()
                {
                    Location = loc,
                    ReportId = report.Id
                });

                return Ok(report);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
