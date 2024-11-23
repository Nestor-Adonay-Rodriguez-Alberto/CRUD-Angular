using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Web_API.Models.Entities
{
    public class Empleado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEmpleado { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Correo { get; set; }
        public double? Sueldo { get; set; }
        public string? FechaContratado { get; set; }
    }
}
