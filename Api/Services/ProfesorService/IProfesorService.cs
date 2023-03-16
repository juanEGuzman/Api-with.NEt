using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Students.Dtos.Profesor;

namespace Students.Services.ProfesorService
{
    public interface IProfesorService
    {
    Task<ServiceResponse<List<GetProfesorDto>>> GetProfesores();
    Task<ServiceResponse<GetProfesorDto>> GetProfesorById(int id); 
    Task<ServiceResponse<List<GetProfesorDto>>> AddProfesor(AddProfesorDto newMateria);
     Task<ServiceResponse<GetProfesorDto>> UpdateProfesor(UpdateProfesorDto updateMateria);
    Task<ServiceResponse<List<GetProfesorDto>>> DeleteProfesor(int id);
    
    }
}