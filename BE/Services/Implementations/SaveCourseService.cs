using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BE.Models;
using BE.Repository.Interface;
using BE.Services.Interfaces;
using BE.Utils;

namespace BE.Services.Implementations
{
    public class SaveCourseService : ISaveCourseService
    {
        private readonly ISaveCourseRepository _saveCourseRepository;

        public SaveCourseService(ISaveCourseRepository saveCourseRepository)
        {
            _saveCourseRepository = saveCourseRepository;
        }

        public async Task<IEnumerable<SaveCourse>> GetAllSaveCoursesAsync()
        {
            return await _saveCourseRepository.GetAllSaveCoursesAsync();
        }

        public async Task<SaveCourse> GetSaveCourseByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("SaveCourse ID cannot be null or empty.");
            }

            var saveCourse = await _saveCourseRepository.GetSaveCourseByIdAsync(id);
            if (saveCourse == null)
            {
                throw new Exception("SaveCourse not found.");
            }

            return saveCourse;
        }

        public async Task AddSaveCourseAsync(SaveCourse saveCourse)
        {
            if (saveCourse == null)
            {
                throw new Exception("SaveCourse cannot be null.");
            }
            saveCourse.Id = Utils.Utils.GenerateIdModel("SaveCourse");
            saveCourse.Time = Utils.Utils.GetTimeNow();
            await _saveCourseRepository.AddSaveCourseAsync(saveCourse);
        }

        public async Task UpdateSaveCourseAsync(SaveCourse saveCourse)
        {
            if (saveCourse == null)
            {
                throw new Exception("SaveCourse cannot be null.");
            }

            var existingSaveCourse = await _saveCourseRepository.GetSaveCourseByIdAsync(saveCourse.Id);
            if (existingSaveCourse == null)
            {
                throw new Exception("SaveCourse not found.");
            }

            await _saveCourseRepository.UpdateSaveCourseAsync(saveCourse);
        }

        public async Task DeleteSaveCourseAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("SaveCourse ID cannot be null or empty.");
            }

            var saveCourse = await _saveCourseRepository.GetSaveCourseByIdAsync(id);
            if (saveCourse == null)
            {
                throw new Exception("SaveCourse not found.");
            }

            await _saveCourseRepository.DeleteSaveCourseAsync(id);
        }
    }
}
