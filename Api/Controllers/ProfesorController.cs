using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Students.Data;
using Students.Dtos.Profesor;
using Students.Services.ProfesorService;

namespace Students.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfesorController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
    public ProfesorController(DataContext context, IMapper mapper)
    {
            _context = context;
            _mapper = mapper;
        
    }

       [HttpGet("Gets")] 
         
       public async Task<ActionResult<List<Profesor>>> GetProfesores()
       {
        var response = new ServiceResponse<List<GetProfesorDto>>();
        var dbProfesor = await _context.Profesores.ToListAsync();

        response.Data = dbProfesor.Select(p => _mapper.Map<GetProfesorDto>(p)).ToList();
        return Ok(response);

       }

      [HttpGet("{id}")]
    
        public async Task<ActionResult<ServiceResponse<GetProfesorDto>>> GetProfesorById(int id) 
        {
            var response = new ServiceResponse<GetProfesorDto>();
            var profesor = await _context.Profesores.FirstOrDefaultAsync(p => p.Id ==id);

            response.Data = _mapper.Map<GetProfesorDto>(profesor);
            return Ok(response);
        }
    [HttpPost]
     public async Task<ActionResult<ServiceResponse<List<GetProfesorDto>>>> AddProfesor(AddProfesorDto newProfesor)
     {
        var response = new ServiceResponse<List<GetProfesorDto>>();
           Profesor profesor = _mapper.Map<Profesor>(newProfesor);

           _context.Profesores.Add(profesor);
           await _context.SaveChangesAsync();

           response.Data = await _context.Profesores.Select(p => _mapper.Map<GetProfesorDto>(p)).ToListAsync();

           return Ok(response);
     }
    [HttpPut("{id}")]
     public async Task<ActionResult<ServiceResponse<GetProfesorDto>>> UpdateProfesor(UpdateProfesorDto updateProfesor)
     {
        var response = new ServiceResponse<GetProfesorDto>();
            
            try
            {
            Profesor profesor = await _context.Profesores.FirstOrDefaultAsync(c=> c.Id == updateProfesor.Id);
            _mapper.Map(updateProfesor, profesor);

            await _context.SaveChangesAsync();
            response.Data = _mapper.Map<GetProfesorDto>(profesor);
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;

     }
     [HttpDelete("{id}")]
    public async Task<ServiceResponse<List<GetProfesorDto>>> DeleteProfesor(int id)
        {
            var response = new ServiceResponse<List<GetProfesorDto>>();
            try{
                Profesor profesor = await _context.Profesores.FirstAsync(p => p.Id == id);
                _context.Profesores.Remove(profesor);
               await _context.SaveChangesAsync();

               response.Data = await _context.Profesores.Select(p => _mapper.Map<GetProfesorDto>(p)).ToListAsync();

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