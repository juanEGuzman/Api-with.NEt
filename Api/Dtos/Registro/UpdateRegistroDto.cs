using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos.Registro
{
    public class UpdateRegistroDto
    {
        public int Id { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}