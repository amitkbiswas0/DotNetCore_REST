using Microsoft.EntityFrameworkCore;

namespace DotNetCore_REST.Models
{
  public class PersonContext : DbContext
  {
    public PersonContext() { }
    public PersonContext(DbContextOptions<PersonContext> options) : base(options) { }

    public DbSet<Person> Persons { get; set; }
  }
}
