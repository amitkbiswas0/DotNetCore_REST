using System;
using System.Collections.Generic;
using System.Linq;
using DotNetCore_REST.Models;

namespace DotNetCore_REST.Data
{
  public class PersonRepo : IPersonRepo
  {
    private readonly PersonContext _context;

    public PersonRepo(PersonContext context) { _context = context; }

    public IEnumerable<Person> GetPeople()
    {
      return _context.Persons.ToList();
    }

    public Person GetPersonById(Guid Id)
    {
      return _context.Persons.FirstOrDefault(row => Id.Equals(row.Id));
    }
  }
}