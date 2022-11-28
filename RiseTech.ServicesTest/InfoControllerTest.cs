using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RiseTech.Data;
using RiseTech.Data.Entities;
using RiseTech.Data.Repositories;
using RiseTech.Data.Repositories.Interfaces;
using RiseTech.Services;
using RiseTech.Services.Controllers;
using RiseTech.Services.DTO;
using System.Collections.Generic;
using Xunit;

namespace RiseTech.ServicesTest
{
    public class InfoControllerTest
    {
        private readonly InfoController _controller;
        private readonly IRepositoryWrapper _service;
        private readonly PhoneBookContext _ctx;
        private readonly IMapper _mapper;
        public InfoControllerTest()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new RiseTech.Services.DTO.Mapping());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;

            _ctx = new PhoneBookContext(new Microsoft.EntityFrameworkCore.DbContextOptions<PhoneBookContext>());
            _service = new RepositoryWrapper(_ctx);
            _controller = new InfoController(_service, _mapper);
        }

        [Fact]
        public void GetInfoByUserIdTest()
        {
            int personId = 1;
            var result = _controller.GetInfos(personId);

            Assert.IsType<OkObjectResult>(result.Result);
            var list = result.Result as OkObjectResult;

            Assert.IsType<List<Info>>(list.Value);
            var infoList = list.Value as List<Info>;
        }

        
        [Fact]
        public void CreateInfoTest()
        {
            InfoDTO info = new InfoDTO()
            {
                Email = "test@test.com",
                Location = "testLocation",
                Telephone = "testPhone"
            };
            var result = _controller.CreateInfo(1, info);

            Assert.IsType<OkObjectResult>(result.Result);
            var data = result.Result as OkObjectResult;

            Assert.IsType<Info>(data.Value);
            var infoObjectObject = data.Value as Info;
        }

    }
}
