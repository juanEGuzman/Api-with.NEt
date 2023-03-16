using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students.Models
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }=string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public Nullable<int> IdProfesor { get; set; }

    }
}