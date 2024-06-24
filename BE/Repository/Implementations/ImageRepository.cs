using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Models;
using BE.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BE.Repository.Implementations
{
    public class ImageRepository : IImageRepository
    {
        private readonly CourseOnlContext _context;
        public ImageRepository(CourseOnlContext context)
        {
            _context = context;
        }
        public async Task<Image?> GetImageByCourseId(string courseId)
        {
            var image = await _context.Images.FirstOrDefaultAsync(i => i.CourseId == courseId);

            if(image == null) return null;

            return image;
        }
    }
}