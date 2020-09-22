using AutoMapper;
using DotNetCore_REST.DTOs;
using DotNetCore_REST.Models;

// DTO profiler to map Model with DTO
namespace DotNetCore_REST.Profiles
{
  public class PersonProfile : Profile
  {
    public PersonProfile()
    {
      CreateMap<Person, PersonReadDTO>();
      CreateMap<PersonCreateDTO, Person>();
      CreateMap<PersonUpdateDTO, Person>();
      CreateMap<Person, PersonUpdateDTO>();
    }
  }
}