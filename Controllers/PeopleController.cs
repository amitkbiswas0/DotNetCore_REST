using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.JsonPatch;

using DotNetCore_REST.Data;
using DotNetCore_REST.DTOs;
using DotNetCore_REST.Models;

namespace DotNetCore_REST.Controllers
{
  // [controller] will be auto replaced by classname minus Controller
  // so [Route("api/[controller]")] means route for api/people
  [Route("api/people")]
  [ApiController]
  public class PeopleController : ControllerBase
  {
    private readonly IPersonRepo _PersonRepo;
    private readonly IMapper _mapper;

    // added IPersonRepo to service containter
    // we can now pass PersonRepo to constructor 
    public PeopleController(IPersonRepo PersonRepo, IMapper mapper)
    {
      _PersonRepo = PersonRepo;
      _mapper = mapper;
    }

    // GET /api/people
    [HttpGet]
    public ActionResult<IEnumerable<PersonReadDTO>> GetAllPerson()
    {
      // _mapper.Map<Destination>(Source)
      return Ok(_mapper.Map<IEnumerable<PersonReadDTO>>(_PersonRepo.GetPeople()));
    }

    // GET /api/people/{id}
    [HttpGet("{id}", Name = "GetPersonById")]
    public ActionResult<Person> GetPersonById(Guid Id)
    {
      return Ok(_mapper.Map<PersonReadDTO>(_PersonRepo.GetPersonById(Id)));
    }

    // POST /api/people
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<PersonReadDTO> CreatePerson(PersonCreateDTO personCreateDTO)
    {
      var Person = _mapper.Map<Person>(personCreateDTO);
      Person.Id = new Guid();

      _PersonRepo.CreatePerson(Person);
      _PersonRepo.SaveChanges();
      // sends location and 201 status with header
      return CreatedAtRoute(nameof(GetPersonById), new { Id = Person.Id }, personCreateDTO);
      // sends 200 status only 
      // return Ok(_mapper.Map<PersonReadDTO>(_PersonRepo.GetPersonById(Person.Id)));
    }

    // PATCH /api/people/{id}
    [HttpPatch("{id}")]
    public ActionResult UpdatePerson(Guid Id, JsonPatchDocument<PersonUpdateDTO> patchDoc)
    {
      var Person = _PersonRepo.GetPersonById(Id);
      if (Person == null)
        return NotFound();

      var PersonToPatch = _mapper.Map<PersonUpdateDTO>(Person);
      patchDoc.ApplyTo(PersonToPatch, ModelState);

      if (!TryValidateModel(PersonToPatch))
        return ValidationProblem(ModelState);

      _mapper.Map(PersonToPatch, Person);
      _PersonRepo.UpdatePerson(Person);
      _PersonRepo.SaveChanges();

      return NoContent();
    }

    //DELETE api/people/{id}
    [HttpDelete("{id}")]
    public ActionResult DeletePerson(Guid Id)
    {
      var Person = _PersonRepo.GetPersonById(Id);
      if (Person == null)
        return NotFound();

      _PersonRepo.DeletePerson(Person);
      _PersonRepo.SaveChanges();

      return NoContent();
    }
  }
}