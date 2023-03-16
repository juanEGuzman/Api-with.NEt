using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students.Dtos.Students
{
    public class GetStudentDto
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; } = "Juan Guzman";
        public int Matricula { get; set; } = 1564562;
       
    }
    
}