using BE.Dto.SaveCourse;
using BE.Dto.Submission;
using BE.Models;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace BE.Controllers
{
    [ApiController]
    [Route("api/v1/web/submission")]
    public class SubmissionController : ControllerBase
    {
        private readonly ISubmissionService _submissionService;

        public SubmissionController(ISubmissionService submissionService)
        {
            _submissionService = submissionService;
        }

        [HttpPost]
        [Route("create-submission")]
        public async Task<ActionResult<Submission>> CreateSubmission(CreateSubmissionDTO createSubmissionDto)
        {
            var submission = await _submissionService.CreateSubmissionAsync(createSubmissionDto);
            return CreatedAtAction(nameof(GetSubmissionById), new { id = submission.Id }, submission);
        }

        [HttpPut("update-submission/{id}")]
        public async Task<ActionResult<Submission>> UpdateSubmission(string id, UpdateSubmissionDTO updateSubmissionDto)
        {
            if (id != updateSubmissionDto.Id)
            {
                return BadRequest("ID mismatch");
            }

            try
            {
                var updatedSubmission = await _submissionService.UpdateSubmissionAsync(updateSubmissionDto);
                return Ok(updatedSubmission);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Submission not found");
            }
        }

        [HttpDelete("delete-submssion/{id}")]
        public async Task<ActionResult> DeleteSubmission(string id)
        {
            await _submissionService.DeleteSubmissionAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Submission>> GetSubmissionById(string id)
        {
            var submission = await _submissionService.GetSubmissionByIdAsync(id);
            if (submission == null)
            {
                return NotFound("Submission not found");
            }

            return Ok(submission);
        }

        [HttpGet]
        public async Task<ActionResult<List<Submission>>> GetAllSubmissions()
        {
            var submissions = await _submissionService.GetAllSubmissionsAsync();
            return Ok(submissions);
        }
    }
}
