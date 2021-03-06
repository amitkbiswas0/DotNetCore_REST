using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetCore_REST.Models
{
  public class Person
  {
    [Key]
    [Required]
    public Guid Id { get; set; }

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