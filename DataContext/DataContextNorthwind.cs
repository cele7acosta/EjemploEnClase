using EjemploEnClase.Model;
using Microsoft.EntityFrameworkCore;

namespace EjemploEnClase.DataContext
{
    public class DataContextNorthwind : DbContext
    {
        public DataContextNorthwind(DbContextOptions<DataContextNorthwind> options) : base(options)
        {

        }

        public DbSet<Employees> Employees { get; set; }

    }
}
