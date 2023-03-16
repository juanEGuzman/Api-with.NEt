using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos.Registro
{
    public class GetRegistroDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; }= string.Empty;
        public string Nombre { get; set; } = "Juan";
        public string Apellido { get; set; } = "Guzman";
        public int Matricula { get; set; } = 1564562;
        public string Materia { get; set; } ="Idiomas";
        public int StudentId { get; set; } 
    }
}