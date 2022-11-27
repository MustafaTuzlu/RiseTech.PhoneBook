using RiseTech.Data.Entities;
using RiseTech.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

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
        public ActionResult<IEnumerable<Report>> GetReports()
        {
            try
            {
                var reports = _repository.Reports.GetAllReports();
                return Ok(reports);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
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

                //Kuyruğa talep gönderilecek.

                return Ok(report);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
