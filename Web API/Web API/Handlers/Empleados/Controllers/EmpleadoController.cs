using Microsoft.AspNetCore.Mvc;
using Web_API.Handlers.Empleados.Interfaces;
using Web_API.Handlers.Empleados.Services;
using Web_API.Models.Entities;


namespace Web_API.Handlers.Empleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        public IEmpleado _empleadoRepository;

        public EmpleadoController(IEmpleado empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }




        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            EmpleadoService _service = new(_empleadoRepository);

            List<Empleado> allEmpleados = await _service.Listar();

            return Ok(allEmpleados);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obtener_PoId(int id)
        {
            EmpleadoService _service = new(_empleadoRepository);

            Empleado? empleado = await _service.Obtener_PoId(id);

            if (empleado == null)
            {
                return NotFound("Registro No Existente.");
            }

            return Ok(empleado);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Empleado empleado)
        {
            EmpleadoService _service = new(_empleadoRepository);

            int Respuesta = await _service.Crear(empleado);

            if (Respuesta > 0)
            {
                return Ok(Respuesta);
            }
            else
            {
                return NotFound(Respuesta);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Editar([FromBody] Empleado empleado)
        {
            EmpleadoService _service = new(_empleadoRepository);

            int Respuesta = await _service.Editar(empleado);

            if (Respuesta > 0)
            {
                return Ok(Respuesta);
            }
            else
            {
                return NotFound(Respuesta);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            EmpleadoService _service = new(_empleadoRepository);

            int Respuesta = await _service.Eliminar(id);

            if (Respuesta > 0)
            {
                return Ok(Respuesta);
            }
            else
            {
                return NotFound(Respuesta);
            }
        }


    }
}
