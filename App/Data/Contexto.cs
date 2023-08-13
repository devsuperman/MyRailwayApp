
using Microsoft.EntityFrameworkCore;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions options) : base(options)
    {
    }
    

    public DbSet<Carro> Carros { get; set; }
}