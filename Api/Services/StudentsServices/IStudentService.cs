using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Students.Dtos.Students;

namespace Students.Services.StudentsServices
{
    public interface IStudentService
    {


    Task<ServiceResponse<List<GetStudentDto>>> GetAllStudents();
    Task<ServiceResponse<GetStudentDto>> GetStudentById(int id); 
    Task<ServiceResponse<List<GetStudentDto>>> AddStudent(AddStudentDto nweStudent);
     Task<ServiceResponse<GetStudentDto>> UpdateStudent(UpdateStudentDto updateStudent);
    Task<ServiceResponse<List<GetStudentDto>>> DeleteStudent(int id);
    
    }
}