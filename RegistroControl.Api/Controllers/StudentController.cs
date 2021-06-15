using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RegistroControl.Core.DTOs;
using RegistroControl.Core.Entities;
using RegistroControl.Core.Interfaces;

namespace RegistroControl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;


        public StudentController(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult> GetStudents()
        {
            var students = await _studentRepository.GetStudents();
            var studentsDto = _mapper.Map<IEnumerable<StudentDto>>(students);
            return Ok(studentsDto);
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult> GetStudent(int idStudent)
        {
            var student = await _studentRepository.GetStudent(idStudent);
            var studentDto = _mapper.Map<Student>(student);
            return Ok(studentDto);
        }

        [HttpPost]
        public async Task<ActionResult> InsertStudent(StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            await _studentRepository.InsertStudent(student);
            return Ok(student);
        }
    }
}