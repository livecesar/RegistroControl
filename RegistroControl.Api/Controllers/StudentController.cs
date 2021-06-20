using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RegistroControl.Api.Responses;
using RegistroControl.Core.DTOs;
using RegistroControl.Core.Entities;
using RegistroControl.Core.Interfaces;

namespace RegistroControl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;


        public StudentController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult> GetStudents()
        {
            var students = await _studentService.GetStudents();
            var studentsDto = _mapper.Map<IEnumerable<StudentDto>>(students);
            var response = new ApiResponse<IEnumerable<StudentDto>>(studentsDto);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetStudent(int idStudent)
        {
            var student = await _studentService.GetStudent(idStudent);
            var studentDto = _mapper.Map<StudentDto>(student);
            var response = new ApiResponse<StudentDto>(studentDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> InsertStudent(StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            await _studentService.InsertStudent(student);

            studentDto = _mapper.Map<StudentDto>(student);

            var response = new ApiResponse<StudentDto>(studentDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateStudent(int id, StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            student.StudentId = id;

            var result = await _studentService.UpdateStudent(student);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete ("{id}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            var result = await _studentService.DeleteStudent(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}