using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Students.Dtos.Materias;

namespace Students.Services.MateriaService
{
    public interface IMateriaService
    {
    Task<ServiceResponse<List<GetMateriaDto>>> GetMaterias();
    Task<ServiceResponse<GetMateriaDto>> GetMateriaById(int id); 
    Task<ServiceResponse<List<GetMateriaDto>>> AddMateria(AddMateriaDto newMateria);
     Task<ServiceResponse<GetMateriaDto>> UpdateMateria(UpdateMateriaDto updateMateria);
    Task<ServiceResponse<List<GetMateriaDto>>> DeleteMateria(int id);

    }
}