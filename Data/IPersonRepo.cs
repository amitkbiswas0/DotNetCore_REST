using System;
using System.Collections.Generic;
using DotNetCore_REST.Models;

namespace DotNetCore_REST.Data
{
  public interface IPersonRepo
  {
    IEnumerable<Person> GetPeople();
    Person GetPersonById(Guid Id);
  }
}