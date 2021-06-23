using System;
using RegistroControl.Core.QueryFilters;
using RegistroControl.Infrastructure.Interfaces;

namespace RegistroControl.Infrastructure.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseuri;

        public UriService(string baseuri)
        {
            _baseuri = baseuri;
        }

        public Uri GetCourseStudentPaginationUri(CourseStudentQueryFilter filter, string actionUrl)
        {
            string baseUrl = $"{_baseuri}{actionUrl}";
            return new Uri(baseUrl);
        }
    }
}
