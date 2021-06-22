using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistroControl.Api.Responses;
using RegistroControl.Core.DTOs;
using RegistroControl.Core.Entities;
using RegistroControl.Core.Interfaces;
using RegistroControl.Core.QueryFilters;

namespace RegistroControl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseStudentController : ControllerBase
    {
        private readonly ICourseStudentService _courseStudentService;
        private readonly IMapper _mapper;

        public CourseStudentController(ICourseStudentService courseStudentService, IMapper mapper)
        {
            _courseStudentService = courseStudentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetCoursesStudent([FromQuery]CourseStudentQueryFilter filters)
        {
            var courseStudents = _courseStudentService.GetCoursesStudent(filters);
            var courseStudentsDto = _mapper.Map<IEnumerable<CourseStudentDto>>(courseStudents);
            var response = new ApiResponse<IEnumerable<CourseStudentDto>>(courseStudentsDto);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCourseStudent(int idStudent)
        {
            var student = await _courseStudentService.GetCourseStudent(idStudent);
            var studentDto = _mapper.Map<StudentDto>(student);
            var response = new ApiResponse<StudentDto>(studentDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> InsertCourseStudent(CourseStudentDto courseStudentDto)
        {
            var courseStudent = _mapper.Map<CourseStudent>(courseStudentDto);
            await _courseStudentService.InsertCourseStudent(courseStudent);

            courseStudentDto = _mapper.Map<CourseStudentDto>(courseStudent);

            var response = new ApiResponse<CourseStudentDto>(courseStudentDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCourseStudent(int id, StudentDto studentDto)
        {
            var student = _mapper.Map<CourseStudent>(studentDto);
            student.StudentId = id;

            var result = await _courseStudentService.UpdateCourseStudent(student);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCourseStudent(int id)
        {
            var result = await _courseStudentService.DeleteCourseStudent(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}