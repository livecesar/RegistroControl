using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RegistroControl.Core.Entities;
using RegistroControl.Core.Interfaces;

namespace RegistroControl.Core.Services
{
    public class CourseStudentService : ICourseStudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseStudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<CourseStudent> GetCourseStudent(int id)
        {
            return _unitOfWork.CourseStudentRepository.GetCourseStudent(id);
        }

        public async Task InsertCourseStudent(CourseStudent courseStudent)
        {
            var courseAlreadySettedForStudent = _unitOfWork.CourseStudentRepository.CourseAlreadyForStudent(courseStudent.CourseId, courseStudent.StudentId).Result;
            if (!courseAlreadySettedForStudent)
            {
                await _unitOfWork.CourseStudentRepository.InsertCourseStudent(courseStudent);
                await _unitOfWork.SavechangesAsync();
            }
            else
            {
                throw new Exception("Course already setted for the student.");
            }

        }

        public async Task<bool> UpdateCourseStudent(CourseStudent courseStudent)
        {
            await _unitOfWork.CourseStudentRepository.UpdateCourseStudent(courseStudent);
            await _unitOfWork.SavechangesAsync();
            return true;
        }

        public Task<bool> DeleteCourseStudent(int id)
        {
            return _unitOfWork.CourseStudentRepository.DeleteCourseStudent(id);
        }

        public Task<IEnumerable<CourseStudent>> GetCoursesStudent()
        {
            return _unitOfWork.CourseStudentRepository.GetCoursesStudent();
        }

        public Task<bool> CourseAlreadyForStudent(int idCourse, int idStudent)
        {
            return _unitOfWork.CourseStudentRepository.CourseAlreadyForStudent(idCourse, idStudent);
        }
    }
}
