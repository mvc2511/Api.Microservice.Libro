using Api.Microservice.Libro.Modelo;
using Microsoft.EntityFrameworkCore;

namespace Api.Microservice.Libro.Persistencia
{
    public class ContextoLibreria : DbContext
    {
        public ContextoLibreria(DbContextOptions<ContextoLibreria> options) : base(options)
        {

        }

        public DbSet<LibreriaMaterial> LibreriasMaterial { get; set; }
    }
}
