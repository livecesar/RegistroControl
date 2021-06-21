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

        public async Task InsertCourseStudent(CourseStudent student)
        {
            await _unitOfWork.CourseStudentRepository.InsertCourseStudent(student);
            await _unitOfWork.SavechangesAsync();
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
            return _unitOfWork.CourseStudentRepository.GetCourseStudent();
        }
    }
}
