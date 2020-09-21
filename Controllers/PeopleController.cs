using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using DotNetCore_REST.Data;
using DotNetCore_REST.DTOs;
using DotNetCore_REST.Models;

namespace DotNetCore_REST.Controllers
{
  // [controller] will be auto replaced by classname minus Controller
  // so [Route("api/[controller]")] means route for api/person
  [Route("api/people")]
  [ApiController]
  public class PeopleController : ControllerBase
  {
    private readonly IPersonRepo _PersonRepo;
    private readonly IMapper _mapper;

    // adding IPersonRepo to service containter lets us do this
    public PeopleController(IPersonRepo PersonRepo, IMapper mapper)
    {
      _PersonRepo = PersonRepo;
      _mapper = mapper;
    }

    // GET /api/Person
    [HttpGet]
    public ActionResult<IEnumerable<PersonReadDTO>> GetAllPerson()
    {
      return Ok(_mapper.Map<IEnumerable<PersonReadDTO>>(_PersonRepo.GetPeople()));
    }

    // GET /api/Person/{id}
    [HttpGet("{id}")]
    public ActionResult<Person> GetPersonById(Guid Id)
    {
      return Ok(_mapper.Map<PersonReadDTO>(_PersonRepo.GetPersonById(Id)));
    }
  }
}