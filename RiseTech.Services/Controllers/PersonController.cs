﻿using AutoMapper;
using RiseTech.Data.Entities;
using RiseTech.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RiseTech.Services.DTO;
using System;
using System.Collections.Generic;

namespace RiseTech.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public PersonController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetPeople()
        {
            try
            {
                var people = _repository.People.GetPeople();
                return Ok(people);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public ActionResult<Person> AddPerson([FromBody] PersonDTO personDto)
        {
            try
            {
                if (personDto is null)
                {
                    return BadRequest("Person object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                Person person = _mapper.Map<Person>(personDto);
                _repository.People.AddPerson(person);
                _repository.Save();
                return Ok(person);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<Person> UpdatePerson(int id, [FromBody] PersonDTO personDto)
        {
            try
            {
                if (personDto is null)
                {
                    return BadRequest("Person object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                Person person = _repository.People.GetPersonByID(id);

                if (person is null)
                {
                    return NotFound();
                }
                _mapper.Map(personDto, person);
                _repository.People.UpdatePerson(person);
                _repository.Save();
                return Ok(person);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePerson(int id)
        {
            try
            {
                Person person = _repository.People.GetPersonByID(id);
                if (person == null)
                {
                    return NotFound();
                }
                _repository.People.DeletePerson(person);
                _repository.Save();
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
