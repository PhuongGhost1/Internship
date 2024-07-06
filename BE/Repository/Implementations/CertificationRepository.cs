using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Models;
using BE.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BE.Repository.Implementations
{
    public class CertificationRepository : ICertificationRepository
    {
        private readonly CourseOnlContext _context;
        public CertificationRepository(CourseOnlContext context)
        {
            _context = context;
        }


        //---------------------CRUD--------------------------//
        public async Task<Certification?> CreateCertification(Certification certification)
        {
            await _context.Certifications.AddAsync(certification);
            await _context.SaveChangesAsync();
            return certification;
        }

        public async Task<List<Certification>> GetAllCertifications()
        {
            return await _context.Certifications.ToListAsync();
        }
    }
}