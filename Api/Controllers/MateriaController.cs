using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Students.Data;
using Students.Dtos.Materias;

namespace Students.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClaseController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
    public ClaseController(DataContext context, IMapper mapper)
    {
            _context = context;
            _mapper = mapper;
        
    }

       [HttpGet("Gets")] 
         
       public async Task<ActionResult<List<GetMateriaDto>>> GetMaterias()
       {
        var response = new ServiceResponse<List<GetMateriaDto>>();
        var dbMateria = await _context.Materias.ToListAsync();

        response.Data = dbMateria.Select(p => _mapper.Map<GetMateriaDto>(p)).ToList();
        return Ok(response);

       }

      [HttpGet("{id}")]
    
        public async Task<ActionResult<ServiceResponse<GetMateriaDto>>> GetMateriaById(int id) 
        {
            var response = new ServiceResponse<GetMateriaDto>();
            var materia = await _context.Materias.FirstOrDefaultAsync(p => p.Id ==id);

            response.Data = _mapper.Map<GetMateriaDto>(materia);
            return Ok(response);
        }
    [HttpPost]
     public async Task<ActionResult<ServiceResponse<List<GetMateriaDto>>>> AddMateria(AddMateriaDto newMateria)
     {
        var response = new ServiceResponse<List<GetMateriaDto>>();
           Materia materia = _mapper.Map<Materia>(newMateria);

           _context.Materias.Add(materia);
           await _context.SaveChangesAsync();

           response.Data = await _context.Materias.Select(p => _mapper.Map<GetMateriaDto>(p)).ToListAsync();

           return Ok(response);
     }
    [HttpPut("{id}")]
     public async Task<ActionResult<ServiceResponse<GetMateriaDto>>> UpdateMateria(UpdateMateriaDto updateMateria)
     {
        var response = new ServiceResponse<GetMateriaDto>();
            
            try
            {
            Materia materia = await _context.Materias.FirstOrDefaultAsync(c=> c.Id == updateMateria.Id);
            _mapper.Map(updateMateria, materia);

            await _context.SaveChangesAsync();
            response.Data = _mapper.Map<GetMateriaDto>(materia);
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;

     }
     [HttpDelete("{id}")]
    public async Task<ServiceResponse<List<GetMateriaDto>>> DeleteMateria(int id)
        {
            var response = new ServiceResponse<List<GetMateriaDto>>();
            try{
                Materia materia = await _context.Materias.FirstAsync(p => p.Id == id);
                _context.Materias.Remove(materia);
               await _context.SaveChangesAsync();

               response.Data = await _context.Materias.Select(p => _mapper.Map<GetMateriaDto>(p)).ToListAsync();

            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            
            return response;
        }
    }
}