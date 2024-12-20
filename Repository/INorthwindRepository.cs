﻿using EjemploEnClase.Model;

namespace EjemploEnClase.Repository
{
    public interface INorthwindRepository
    {
        Task<List<Employees>> ObtenerTodosLosEmpleados();
        Task<int> ObtenerCantidadEmpleados();
        Task<Employees> ObtenerEmpleadoPorID(int id);

        Task<Employees> ObtenerEmpleadosPorNombre(string nombreEmpleado);
        Task<Employees?> ObtenerIDEmpleadoPorTitulo(string titulo);
        Task<Employees> ObtenerEmpleadoPorPais(string country);
        Task<List<Employees>> ObtenerTodosLosEmpleadosPorPais(string country);
        Task<Employees> ObtenerElEmpleadoMasGrande();
        Task<IEnumerable<object>> ObtenerCantidadDeEmpleadosPorTitulo();
        Task<IEnumerable<object>> ObtenerProductosConCategoria();
        Task<IEnumerable<object>> ObtenerProductosConChef();
        Task<bool> ModificarNombreEmpleado(int idEmpleado, string nombre);
        Task<bool> EliminarOrdenPorID(int orderID);
        Task<bool> InsertarEmpleado();
    }
}
