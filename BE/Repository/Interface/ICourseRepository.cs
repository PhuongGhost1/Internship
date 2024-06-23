using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Models;

namespace BE.Repository.Interface
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllCourses();
        Task<Course?> RetriveCourseInformationById(string courseId, string userId);
        Task<float?> RetriveRatingAverage(string courseId, string userId);
        Task<int?> RetriveRatingNumber(string courseId, string userId);
    }
}