using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Dto.Course
{
    public class MonthlyAnalyticsDto
    {
        public string Month { get; set; } = string.Empty;
        public float? Expense { get; set; }
        public float? Revenue { get; set; }        
    }
}