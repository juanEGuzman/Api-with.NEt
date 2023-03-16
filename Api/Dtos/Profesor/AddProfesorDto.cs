using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students.Dtos.Profesor
{
    public class AddProfesorDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; }= string.Empty;
    }
}