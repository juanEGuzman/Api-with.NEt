using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Students.Data;
using Students.Dtos.Students;

namespace Students.Services.StudentsServices
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;

        private readonly DataContext _context;

        public StudentService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetStudentDto>>> GetAllStudents()
        {
            var serviceResponse = new ServiceResponse<List<GetStudentDto>>();
            var dbStudents = await _context.Students.ToListAsync();

            serviceResponse.Data = dbStudents.Select(c => _mapper.Map<GetStudentDto>(c)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetStudentDto>> GetStudentById(int id)
        {
            var serviceResponse = new ServiceResponse<GetStudentDto>();
            var  student = await  _context.Students.FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetStudentDto>(student);

            return serviceResponse;
        }

         public async Task<ServiceResponse<List<GetStudentDto>>> AddStudent(AddStudentDto newStudent)
        {
            var serviceResponse = new ServiceResponse<List<GetStudentDto>>();
            Student student = _mapper.Map<Student>(newStudent);
            
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Students.Select(c => _mapper.Map<GetStudentDto>(c)).ToListAsync();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetStudentDto>> UpdateStudent(UpdateStudentDto updateStudent)
        {
            ServiceResponse<GetStudentDto> response = new ServiceResponse<GetStudentDto>();

            try{
                Student student = await _context.Students.FirstOrDefaultAsync(c => c.Id == updateStudent.Id);
                _mapper.Map(updateStudent, student);

               await _context.SaveChangesAsync();
                response.Data = _mapper.Map<GetStudentDto>(student);

            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }


        public async Task<ServiceResponse<List<GetStudentDto>>> DeleteStudent (int id)
        {
            var serviceResponse = new ServiceResponse<List<GetStudentDto>>();

            try{
            Student student = await _context.Students.FirstAsync(c => c.Id ==id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Students.Select(c => _mapper.Map<GetStudentDto>(c)).ToListAsync();
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}