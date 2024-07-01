using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BE.Models;
using BE.Repository.Interface;
using BE.Services.Interfaces;
using BE.Utils;

namespace BE.Services.Implementations
{
    public class EnrollCourseService : IEnrollCourseService
    {
        private readonly IEnrollCourseRepository _enrollCourseRepository;

        public EnrollCourseService(IEnrollCourseRepository enrollCourseRepository)
        {
            _enrollCourseRepository = enrollCourseRepository;
        }

        public async Task<IEnumerable<EnrollCourse>> GetAllEnrollCoursesAsync()
        {
            return await _enrollCourseRepository.GetAllEnrollCoursesAsync();
        }

        public async Task<EnrollCourse> GetEnrollCourseByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("EnrollCourse ID cannot be null or empty.");
            }

            var enrollCourse = await _enrollCourseRepository.GetEnrollCourseByIdAsync(id);
            if (enrollCourse == null)
            {
                throw new Exception("EnrollCourse not found.");
            }

            return enrollCourse;
        }

        public async Task AddEnrollCourseAsync(EnrollCourse enrollCourse)
        {
            if (enrollCourse == null)
            {
                throw new Exception("EnrollCourse cannot be null.");
            }
            enrollCourse.Id = Utils.Utils.GenerateIdModel("EnrollCourse");
            enrollCourse.Date = Utils.Utils.GetTimeNow();

            await _enrollCourseRepository.AddEnrollCourseAsync(enrollCourse);
        }

        public async Task UpdateEnrollCourseAsync(EnrollCourse enrollCourse)
        {
            if (enrollCourse == null)
            {
                throw new Exception("EnrollCourse cannot be null.");
            }

            var existingEnrollCourse = await _enrollCourseRepository.GetEnrollCourseByIdAsync(enrollCourse.Id);
            if (existingEnrollCourse == null)
            {
                throw new Exception("EnrollCourse not found.");
            }

            await _enrollCourseRepository.UpdateEnrollCourseAsync(enrollCourse);
        }

        public async Task DeleteEnrollCourseAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("EnrollCourse ID cannot be null or empty.");
            }

            var enrollCourse = await _enrollCourseRepository.GetEnrollCourseByIdAsync(id);
            if (enrollCourse == null)
            {
                throw new Exception("EnrollCourse not found.");
            }

            await _enrollCourseRepository.DeleteEnrollCourseAsync(id);
        }
    }
}
