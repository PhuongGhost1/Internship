using BE.Attributes;
using BE.Dto.Certification;
using BE.Dto.UserCertification;
using BE.Models;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
     [ApiController]
     [Route("api/v1/web/certification")]
     public class CertificationWebController
     {
          private readonly ICertificationService _certiService;
          public CertificationWebController(ICertificationService certiService)
          {
               _certiService = certiService;
          }


          //---------------------CRUD--------------------------//
          [CustomAuthorize("Student", "Instructor")]
          [HttpGet]
          [Route("view-all-certifications")]
          public async Task<List<Certification>> ViewAllCertifications()
          {
               return await _certiService.ViewAllCertifications();
          }

          [CustomAuthorize("Instructor")]
          [HttpPost]
          [Route("create-certification")]
          public async Task<Certification?> CreateCertification([FromForm] CreateCertificatonDto createCertificatonDto)
          {
               return await _certiService.CreateCertification(createCertificatonDto);
          }

          [HttpGet, Route("credentials")]
          public async Task<List<UserCertificationDto>> Credentials([FromQuery] string UserId)
          {
               return await _certiService.GetCredentialsByUserAsync(UserId);
          }
     }
}