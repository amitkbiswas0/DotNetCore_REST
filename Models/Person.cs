using System;

namespace DotNetCore_REST.Models
{
  public class Person
  {
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime Birthday { get; set; }
  }
}