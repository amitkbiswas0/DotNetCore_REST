using System;
using System.Linq;
using System.Collections.Generic;

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

    public void CreatePerson(Person person)
    {
      if (person == null)
        throw new ArgumentException(nameof(person));

      _context.Persons.Add(person);
    }

    public void UpdatePerson(Person person) { }

    public void DeletePerson(Person person)
    {
      if (person == null)
        throw new ArgumentException(nameof(person));

      _context.Persons.Remove(person);
    }

    public void SaveChanges()
    {
      _context.SaveChanges();
    }
  }
}