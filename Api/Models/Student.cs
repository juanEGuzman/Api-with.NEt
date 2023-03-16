using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students.Models
{
    public class Student
    {   
        public int Id { get; set; }
        public string NombreCompleto { get; set; } = "Juan Guzman";
        public int Matricula { get; set; } = 1564562;
                
        public virtual Usuario User { get; set; }
    }
}

