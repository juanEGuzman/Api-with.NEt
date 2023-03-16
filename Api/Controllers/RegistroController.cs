using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos.Registro;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Students.Data;
using Students.Dtos.Profesor;
using Students.Dtos.Students;
using Students.Services.StudentsServices;

namespace Students.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistroController : ControllerBase
    {
        
        public List<Registro> Users = new List<Registro>();
        public IMapper _mapper;
        private readonly IStudentService _studentService;
        private readonly DataContext _context;

        public RegistroController(IMapper mapper, IStudentService studentService, DataContext context)
        {
            _mapper = mapper;
            _studentService =studentService;
            _context = context;
            
            
        }
        [HttpPost("Estudiante")]
        public async Task<ActionResult<ServiceResponse<Usuario>>> RegistroEstudiante(AddStudentDto student, string Password)
        {

            await _studentService.AddStudent(student);

            Usuario usuario = new Usuario();
            
            usuario.Username = CreateUsername(student.NombreCompleto);
            usuario.Password = BCrypt.Net.BCrypt.HashPassword(Password);
            usuario.StudentId = student.Id;
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            
            

            // Registro registro = _mapper.Map<Registro>(student);
            // registro.Nombre= student.NombreCompleto.Split(' ')[0].ToString();
            // registro.Materia = student.Materia;
            // registro.Matricula = student.Matricula;
            // registro.Username = CreateUsername(student.NombreCompleto);
            // registro.Password = BCrypt.Net.BCrypt.HashPassword(Password);

            // Users.Add(registro);

            return Ok(Users);    
        }
        [HttpPost]
        public ActionResult<ServiceResponse<GetRegistroDto>>RegistroProfesor(AddProfesorDto profesor, string Password)
        {
           
            Registro registro = _mapper.Map<Registro>(profesor);
            

            registro.Nombre = profesor.Nombre;
            registro.Apellido = profesor.Apellido;
            registro.Materia = profesor.Apellido;
            registro.Username = CreateUsername(profesor.Nombre, profesor.Apellido);
            registro.Password = BCrypt.Net.BCrypt.HashPassword(Password);

            Users.Add(registro);

            return Ok(Users);    
        }



        public static string CreateUsername(string nombre, string Apellido){

            var Username = nombre[0] + Apellido;

            return Username;

        }
        public static string CreateUsername(string nombreCompleto){

            var nombre = nombreCompleto.Split(' ')[0].ToString();
            var Apellido = nombreCompleto.Split(' ')[1].ToString();
            var Username = nombre[0] + Apellido;

            return Username;

        }

       

    }
}