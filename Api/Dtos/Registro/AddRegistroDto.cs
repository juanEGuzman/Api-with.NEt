using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos.Registro
{
    public class AddRegistroDto
    {
        public string Nombre { get; set; } = "Juan";
        public string Apellido { get; set; } = "Guzman";

        public string Username { get; set; } = string.Empty;
        public string Password { get; set; }= string.Empty;
        public int Matricula { get; set; } = 1564562;
        public string Materia { get; set; } ="Idiomas";
        public int UserId { get; set; }
    }
}