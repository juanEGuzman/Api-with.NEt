using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Students.Data;
using Students.Dtos.Materias;

namespace Students.Services.MateriaService
{
    public class MateriaService : IMateriaService
    {
        private readonly IMapper _mapper;

        private readonly DataContext _context;

        public MateriaService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task<ServiceResponse<List<GetMateriaDto>>> AddMateria(AddMateriaDto newMateria)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetMateriaDto>>> DeleteMateria(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetMateriaDto>> GetMateriaById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetMateriaDto>>> GetMaterias()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetMateriaDto>> UpdateMateria(UpdateMateriaDto updateMateria)
        {
            throw new NotImplementedException();
        }
    }
}