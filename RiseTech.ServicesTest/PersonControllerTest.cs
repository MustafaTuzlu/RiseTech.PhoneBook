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
    public class PersonControllerTest
    {
        private readonly PersonController _controller;
        private readonly IRepositoryWrapper _service;
        private readonly PhoneBookContext _ctx;
        private readonly IMapper _mapper;
        public PersonControllerTest()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new RiseTech.Services.DTO.Mapping());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;

            _ctx = new PhoneBookContext(new Microsoft.EntityFrameworkCore.DbContextOptions<PhoneBookContext>());
            _service = new RepositoryWrapper(_ctx);
            _controller = new PersonController(_service, _mapper);
        }

        [Fact]
        public void GetPeopleTest()
        {
            var result = _controller.GetPeople();

            Assert.IsType<OkObjectResult>(result.Result);
            var list = result.Result as OkObjectResult;

            Assert.IsType<List<Person>>(list.Value);
            var people = list.Value as List<Person>;
        }

        [Fact]
        public void AddPersonTest()
        {
            PersonDTO person = new PersonDTO()
            {
                Name = "Mustafa",
                Surname = "Tuzlu",
                Company = "Rise Tech"
            };
            var result = _controller.AddPerson(person);

            Assert.IsType<OkObjectResult>(result.Result);
            var data = result.Result as OkObjectResult;

            Assert.IsType<Person>(data.Value);
            var personObject = data.Value as Person;
        }

        [Fact]
        public void UpdatePersonTest()
        {
            PersonDTO person = new PersonDTO()
            {
                Name = "Mustafa1",
                Surname = "Tuzlu1",
                Company = "Rise Tech1"
            };
            var result = _controller.UpdatePerson(1, person);

            Assert.IsType<OkObjectResult>(result.Result);
            var data = result.Result as OkObjectResult;

            Assert.IsType<Person>(data.Value);
            var personObject = data.Value as Person;
        }

        [Fact]
        public void DeletePersonTest()
        {
            var result = _controller.DeletePerson(-1);

            Assert.IsType<OkObjectResult>(result);
            var data = result as OkObjectResult;
        }

    }
}
