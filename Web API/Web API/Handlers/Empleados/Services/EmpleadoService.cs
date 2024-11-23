using Web_API.Handlers.Empleados.Interfaces;
using Web_API.Models.Entities;

namespace Web_API.Handlers.Empleados.Services
{
    public class EmpleadoService
    {
        public IEmpleado _EmpleadoRepository;

        public EmpleadoService(IEmpleado empleado)
        {
            _EmpleadoRepository = empleado;
        }



        public async Task<List<Empleado>> Listar()
        {
            List<Empleado> Lista = await _EmpleadoRepository.Listar();
                  
            return Lista;
        }

        public async Task<Empleado> Obtener_PoId(int Id)
        {
            Empleado? empleado = await _EmpleadoRepository.Obtener_PoId(Id);

            if (empleado == null)
            {
                return null;
            }
          
            return empleado;
        }

        public async Task<int> Crear(Empleado empleado)
        {            
            return await _EmpleadoRepository.Crear(empleado);
        }

        public async Task<int> Editar(Empleado empleado)
        {
            Empleado? encontrado = await _EmpleadoRepository.Obtener_PoId(empleado.IdEmpleado);

            if (encontrado == null)
            {
                return 0;
            }

            encontrado.IdEmpleado = empleado.IdEmpleado;
            encontrado.NombreCompleto = empleado.NombreCompleto;
            encontrado.Correo = empleado.Correo;
            encontrado.Sueldo = empleado.Sueldo;
            encontrado.FechaContratado = empleado.FechaContratado;

            return await _EmpleadoRepository.Editar(encontrado);
        }

        public async Task<int> Eliminar(int Id)
        {
            Empleado? encontrado = await _EmpleadoRepository.Obtener_PoId(Id);

            if (encontrado == null)
            {
                return 0;
            }

            return await _EmpleadoRepository.Eliminar(encontrado);
        }


    }
}
