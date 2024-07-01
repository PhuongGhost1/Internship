using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Certification;
using BE.Mappers;
using BE.Models;
using BE.Repository.Interface;
using BE.Services.Interfaces;

namespace BE.Services.Implementations
{
    public class CertificationService : ICertificationService
    {
        private readonly ICertificationRepository _certiRepo;
        private readonly ICourseRepository _courseRepo;
        public CertificationService(ICertificationRepository certiRepo, ICourseRepository courseRepo)
        {
            _certiRepo = certiRepo;
            _courseRepo = courseRepo;
        }


        //---------------------CRUD--------------------------//
        public async Task<Certification?> CreateCertification(CreateCertificatonDto createCertificatonDto)
        {
            var course = await _courseRepo.RetriveCourseInformationById(createCertificatonDto.CourseId);

            if(course == null) throw new Exception("Unable to find course!");

            var createCertification = createCertificatonDto.ToCreateCertificationDto(createCertificatonDto.CourseId);

            if(createCertification == null) throw new Exception("Unable to create course!");

            return await _certiRepo.CreateCertification(createCertification);
        }

        public async Task<List<Certification>> ViewAllCertifications()
        {
            return await _certiRepo.GetAllCertifications();
        }
    }
}