using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetCore_REST.DTOs
{
  public class PersonReadDTO
  {
    [Required]
    [MaxLength(250)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(250)]
    public string LastName { get; set; }

    [Required]
    public DateTime Birthday { get; set; }
  }
}