using BE.Dto.UserCertification;
using BE.Models;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [ApiController]
    [Route("api/v1/web/role-user")]
    public class UserCertificationWebController 
    {
        private readonly IUserCertificationService _userCertificationService;
        public UserCertificationWebController(IUserCertificationService userCertificationService)
        {
            _userCertificationService = userCertificationService;
        }


        //---------------------CRUD--------------------------//
        [HttpGet]
        [Route("view-all-userCertifications")]
        public async Task<List<UserCertification>> ViewAllUserCertifications(){
            return await _userCertificationService.ViewAllUserCertifications();
        }

        [HttpPost]
        [Route("create-userCertification")]
        public async Task<UserCertification?> CreateUserCertification([FromForm] CreateUserCertificationDto createUserCertificationDto){
            return await _userCertificationService.CreateUserCertification (createUserCertificationDto);
        }

        [HttpPost]
        [Route("update-userCertification")]
        public async Task<UserCertification?> UpdateUserCertification([FromForm] string userCertificationId, [FromForm] UpdateUserCertificationDto updateUserCertificationDto){
            return await _userCertificationService.UpdateUserCertification(userCertificationId, updateUserCertificationDto);
        }

        [HttpPost]
        [Route("delete-userCertification")]
        public async Task<bool> DeleteUserCertification([FromForm] string userCertificationId){
            return await _userCertificationService.DeleteUserCertification(userCertificationId);
        }
    }
}
