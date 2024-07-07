using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Dto.Email
{
    public class EmailSendResultDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string ErrorDetails { get; set; }
        public DateTime Timestamp { get; set; }
    }
}