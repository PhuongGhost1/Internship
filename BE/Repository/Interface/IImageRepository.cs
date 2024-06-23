using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Models;

namespace BE.Repository.Interface
{
    public interface IImageRepository
    {
        Task<Image?> GetImageByCourseId(string courseId);
    }
}