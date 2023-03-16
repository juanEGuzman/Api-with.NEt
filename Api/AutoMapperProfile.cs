using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos.Registro;
using AutoMapper;
using Students.Dtos.Materias;
using Students.Dtos.Profesor;
using Students.Dtos.Students;

namespace Students
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile(){
            

        CreateMap<Student, GetStudentDto>();
        CreateMap<AddStudentDto, Student>();
        CreateMap<UpdateStudentDto, Student>();

        //Profesor Map
        CreateMap<Profesor, GetProfesorDto>();
        CreateMap<AddProfesorDto, Profesor>();
        CreateMap<UpdateProfesorDto, Profesor>();

        //Materias Map
        CreateMap<Materia, GetMateriaDto>();
        CreateMap<AddMateriaDto, Materia>();
        CreateMap<UpdateMateriaDto, Materia>();

        //Registro Map 
        CreateMap<AddStudentDto, Registro>();
        CreateMap<AddProfesorDto, Registro>();
        // CreateMap<AddStudentDto, Usuario >
        
        }
    }
}