using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Pederli.API.ViewModel;
using Pederli.Entity;
using Pederli.Service.Abstract;

namespace Pederli.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IService<Person> _personService;

        private readonly IMapper _mapper;

        public PersonController(IService<Person> personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _personService.GetList();

            return Ok(persons);
        }

        [HttpPost]
        public async Task<IActionResult> Save(PersonViewModel personViewModel)
        {
            Person person = await _personService.Add(_mapper.Map<Person>(personViewModel));

            return Created(String.Empty, _mapper.Map<PersonViewModel>(person));
        } 
    }
}
