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

        // GROUP BY
        public async Task<IEnumerable<object>> ObtenerCantidadDeEmpleadosPorTitulo()
        {
            var result = from emp in _dataContext.Employees
                         group emp by emp.Title into grouped
                         select new 
                         {
                             Title = grouped.Key,
                             cantidad = grouped.Count()
                         };

            return await result.ToListAsync();
        }

        //INNER JOIN

        public async Task<IEnumerable<object>> ObtenerProductosConCategoria()
        {
            var result = from prod in _dataContext.Products
                         join cat in _dataContext.Categories on prod.CategoryID equals cat.CategoryID
                         select new
                         {
                             Producto = prod.ProductName,
                             Categoria = cat.CategoryName
                         };

            return await result.ToListAsync();
        }

        // LIKE

        public async Task<IEnumerable<object>> ObtenerProductosConChef()
        {
            var result = from prod in _dataContext.Products
                         where prod.ProductName.Contains("chef")
                         select new
                         {
                             Producto = prod.ProductName,
                             Precio = prod.UnitPrice
                         };

            return await result.ToListAsync();
        }

        public async Task<bool> ModificarNombreEmpleado(int idEmpleado, string nombre)
        {
            bool actualizado = false;
            Employees result = await _dataContext.Employees.Where(r => r.EmployeeID == idEmpleado).FirstOrDefaultAsync();

            if (result != null)
            {
                result.FirstName = nombre;
                var resulta = _dataContext.SaveChanges();
                actualizado = true;
            }

            return actualizado;
        }

        public async Task<bool> EliminarOrdenPorID(int orderID)
        {
            Orders? orden = await _dataContext.Orders.Where(r => r.OrderID == orderID).FirstOrDefaultAsync();
            OrderDetails? ordenDetail = await _dataContext.OrderDetails.Where(r => r.OrderID == orden.OrderID).FirstOrDefaultAsync();

            _dataContext.OrderDetails.Remove(ordenDetail);
            _dataContext.Orders.Remove(orden);

            var resulta = _dataContext.SaveChanges();
            return true;
        }

        public async Task<bool> InsertarEmpleado()
        {
            Employees employee = new Employees();
            employee.Title = "Sales Manager";
            employee.City = "Rosario";
            employee.FirstName = "Celeste";
            employee.LastName = "Acosta";
            employee.HireDate = DateTime.Now;
            employee.BirthDate = DateTime.Now;
            var newEmployee = await _dataContext.AddAsync(employee);
            var result = _dataContext.SaveChanges();

            return (result > 0);
        }
    }
}
