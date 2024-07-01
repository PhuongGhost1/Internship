using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Course;
using BE.Helpers;
using BE.Models;

namespace BE.Services.Interfaces
{
    public interface ICourseService
    {
        Task<List<Course>> GetAllCourses(SearchQueryObject searchQueryObject);
        Task<List<Course>> FilterAllCourses(FilterQueryObject filterQueryObject);
        Task<CourseDto> GetInformationOfCourse(string courseId);
        Task<List<object>> GetLecturesAndQuizzesByCourseId(string courseId);
        Task<string> UploadImgCourse(int courseId, IFormFile image);
        Task<string> CreateCourse(CreateCoursData data);
        Task<List<Course>> GetAllCoursesByCategoryName(string cateName);


        //---------------------CRUD--------------------------//
        Task<Course?> CreateCourse(CreateCourseDto createCourseDto);
        Task<Course?> UpdateCourse(UpdateCourseDto updateCourseDto);
        Task<bool> DeleteCourse(string courseId);
    }
}