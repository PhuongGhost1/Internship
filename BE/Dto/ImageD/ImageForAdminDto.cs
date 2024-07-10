using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Dto.ImageD
{
    public class ImageForAdminDto
    {
        public string? Id { get; set; }
        public string? Url { get; set; }
        public string? Type { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}