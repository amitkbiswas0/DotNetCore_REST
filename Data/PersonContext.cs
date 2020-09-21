using Microsoft.EntityFrameworkCore;

namespace DotNetCore_REST.Models
{
  public partial class PersonContext : DbContext
  {
    public PersonContext() { }
    public PersonContext(DbContextOptions<PersonContext> options) : base(options) { }

    public DbSet<Person> Persons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Person>(entity =>
            {
              entity.ToTable("persons");

              entity.Property(e => e.Id).HasColumnName("id");

              entity.Property(e => e.FirstName)
                  .IsRequired()
                  .HasColumnName("first_name")
                  .HasMaxLength(250);

              entity.Property(e => e.LastName)
                  .IsRequired()
                  .HasColumnName("last_name")
                  .HasMaxLength(250);

              entity.Property(e => e.Birthday)
                  .IsRequired()
                  .HasColumnName("bday");
            });
      OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}
