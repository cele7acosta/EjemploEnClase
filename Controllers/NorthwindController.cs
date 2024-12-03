using EjemploEnClase.EjemploConDY;
using EjemploEnClase.Model;
using EjemploEnClase.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EjemploEnClase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NorthwindController : ControllerBase
    {
        private readonly INorthwindRepository _repository;
        public NorthwindController(INorthwindRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [Route("api/TodosLosEmpleados")]
        public async Task<List<Employees>> ObtenerTodosLosEmpleados()
        {
            return await _repository.ObtenerTodosLosEmpleados();
        }

        [HttpGet]
        [Route("api/CantidadEmpleados")]

        public async Task<int> ObtenerCantidadEmpleados()
        {
            return await _repository.ObtenerCantidadEmpleados();
        }


        [HttpGet]
        [Route("api/ObtenerEmpleadoPorID")]

        public async Task<Employees> EmpleadoPorID([FromQuery] int empleadoID)
        {
            return await _repository.ObtenerEmpleadoPorID(empleadoID);
        }


        [HttpGet]
        [Route("api/EmpleadosPorNombre")]

        public async Task<Employees> ObtenerEmpleadoPorNombre([FromQuery] string nombreEmpleado)
        {
            return await _repository.ObtenerEmpleadosPorNombre(nombreEmpleado);
        }

        [HttpGet]
        [Route("api/IDEmpleadoPorTitulo")]

        public async Task<Employees> ObtenerEmpleadoPorTitulo([FromQuery] string titulo)
        {
            return await _repository.ObtenerIDEmpleadoPorTitulo(titulo);
        }

        [HttpGet]
        [Route("api/EmpleadoPorPais")]

        public async Task<Employees> ObtenerEmpleadoPorPais([FromQuery] string country)
        {
            return await _repository.ObtenerEmpleadoPorPais(country);
        }

        [HttpGet]
        [Route("api/TodosLosEmpleadoPorPais")]

        public async Task<List<Employees>> ObtenerTodosLosEmpleadoPorPais([FromQuery] string country)
        {
            return await _repository.ObtenerTodosLosEmpleadosPorPais(country);
        }

        [HttpGet]
        [Route("api/ElEmpleadoMasGrande")]

        public async Task<Employees> ObtenerElEmpleadoMasGrande()
        {
            return await _repository.ObtenerElEmpleadoMasGrande();
        }

        [HttpGet]
        [Route("api/CantidadDeEmpleadosPorTitulo")]
        public async Task<IEnumerable<object>> ObtenerCantidadDeEmpleadosPorTitulo()
        {
            return await _repository.ObtenerCantidadDeEmpleadosPorTitulo();
        }

        [HttpGet]
        [Route("api/ProductosConCategoria")]
        
        public async Task<IEnumerable<object>> ObtenerProductosConCategoria()
        {
            return await _repository.ObtenerProductosConCategoria();
        }

        [HttpGet]
        [Route("api/ProductosConChef")]
        
        public async Task<IEnumerable<object>> ObtenerProductosConChef()
        {
            return await _repository.ObtenerProductosConChef();
        }

        [HttpPut]
        [Route("api/ModificarNombreEmpleado")]

        public async Task<bool> ModificarNombreEmpleado([Required, FromQuery] int id, [Required, FromQuery] string nombre)
        {
            return await _repository.ModificarNombreEmpleado(id, nombre);
        }

        [HttpDelete]
        [Route("api/EliminarOrdenPorID")]
        public async Task<bool> EliminarOrdenPorID([Required,FromQuery] int id)
        {
            return await _repository.EliminarOrdenPorID(id);
        }

        [HttpPut]
        [Route("api/InsertarEmpleado")]

        public async Task<bool> InsertarEmpleado()
        {
            return await _repository.InsertarEmpleado();
        }


    }
}

