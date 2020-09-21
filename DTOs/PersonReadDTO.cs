using System;

namespace DotNetCore_REST.DTOs
{
  public class PersonReadDTO
  {
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime Birthday { get; set; }
  }
}