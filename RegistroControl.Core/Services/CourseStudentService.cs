using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegistroControl.Core.Entities;
using RegistroControl.Core.Exceptions;
using RegistroControl.Core.Interfaces;
using RegistroControl.Core.QueryFilters;

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
                throw new BusinessException("Course already setted for the student.");
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

        public IEnumerable<CourseStudent> GetCoursesStudent(CourseStudentQueryFilter filter)
        {
            var coursesStudent = _unitOfWork.CourseStudentRepository.GetCoursesStudent();

            if (filter.IdCourse != null)
            {
                coursesStudent = coursesStudent.Where(x=>x.CourseId == filter.IdCourse);
            }
            if (filter.IdStudent != null)
            {
                coursesStudent = coursesStudent.Where(x => x.StudentId == filter.IdStudent);
            }
            if (filter.Active != null)
            {
                coursesStudent = coursesStudent.Where(x => x.Active);
            }
            return coursesStudent;
        }

        public Task<bool> CourseAlreadyForStudent(int idCourse, int idStudent)
        {
            return _unitOfWork.CourseStudentRepository.CourseAlreadyForStudent(idCourse, idStudent);
        }
    }
}
