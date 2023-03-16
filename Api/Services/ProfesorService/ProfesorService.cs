using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Students.Data;
using Students.Dtos.Profesor;

namespace Students.Services.ProfesorService
{
    public class ProfesorService : IProfesorService
    {
        private readonly IMapper _mapper;

        private readonly DataContext _context;

        public ProfesorService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetProfesorDto>>> GetProfesores()
        {
            var response = new ServiceResponse<List<GetProfesorDto>>();
            var dbProfesor = await _context.Profesores.ToListAsync();

            response.Data = dbProfesor.Select(p => _mapper.Map<GetProfesorDto>(p)).ToList();

            return response;
        }

        public async Task<ServiceResponse<GetProfesorDto>> GetProfesorById(int id)
        {
            var response = new ServiceResponse<GetProfesorDto>();
            var profesor = await _context.Profesores.FirstOrDefaultAsync(p => p.Id ==id);

            response.Data = _mapper.Map<GetProfesorDto>(profesor);

            return response;
        }

        public async Task<ServiceResponse<List<GetProfesorDto>>> AddProfesor(AddProfesorDto newProfesor)
        {
            var response = new ServiceResponse<List<GetProfesorDto>>();
           Profesor profesor = _mapper.Map<Profesor>(newProfesor);

           _context.Profesores.Add(profesor);
           await _context.SaveChangesAsync();

           response.Data = await _context.Profesores.Select(p => _mapper.Map<GetProfesorDto>(p)).ToListAsync();

           return response;
        }
 public async Task<ServiceResponse<GetProfesorDto>> UpdateProfesor(UpdateProfesorDto updateProfesor)
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