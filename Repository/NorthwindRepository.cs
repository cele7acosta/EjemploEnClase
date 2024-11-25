using EjemploEnClase.Model;
using EjemploEnClase.DataContext;
using Microsoft.EntityFrameworkCore;
namespace EjemploEnClase.Repository
{
    public class NorthwindRepository : INorthwindRepository
    {
        private readonly DataContextNorthwind _dataContext;

        public NorthwindRepository(DataContextNorthwind dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<Employees>> ObtenerTodosLosEmpleados()
        {
            var result = await _dataContext.Employees.ToListAsync();
            return result;
        }

        public async Task<int> ObtenerCantidadEmpleados()
        {
            var result = await _dataContext.Employees.CountAsync();
            return result;
        }

        public async Task<Employees> ObtenerEmpleadoPorID(int id)
        {
            var result = await _dataContext.Employees.Where(e=> e.EmployeeID == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<Employees> ObtenerEmpleadosPorNombre(string nombreEmpleado)
        {
            var result = await _dataContext.Employees.FirstOrDefaultAsync(e => e.FirstName == nombreEmpleado);
            return result;
        }

        public async Task<Employees?> ObtenerIDEmpleadoPorTitulo(string titulo)
        {
            var result = from emp in _dataContext.Employees where emp.Title == titulo select emp;
            return await result.FirstOrDefaultAsync();
        }

        public async Task<Employees> ObtenerEmpleadoPorPais(string country)
        {
            var result = from emp in _dataContext.Employees
                         where emp.Country == country
                         select new Employees
                         {
                             Title = emp.Title,
                             FirstName = emp.FirstName
                         };

            return await result.FirstOrDefaultAsync();
        }

        public async Task<List<Employees>> ObtenerTodosLosEmpleadosPorPais(string country)
        {
            var result = from emp in _dataContext.Employees
                         where emp.Country == country
                         orderby emp.FirstName
                         select new Employees
                         {
                             Title = emp.Title,
                             FirstName = emp.FirstName
                         };

            return await result.ToListAsync();
        }


        public async Task<Employees> ObtenerElEmpleadoMasGrande()
        {
            var result = from emp in _dataContext.Employees
                         orderby emp.BirthDate
                         select new Employees
                         {
                             Title = emp.Title,
                             FirstName = emp.FirstName,
                             LastName = emp.LastName
                         };

            return await result.FirstOrDefaultAsync();
        }
    }
}
