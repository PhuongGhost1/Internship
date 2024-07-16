using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Answer;
using BE.Dto.Feedback;
using BE.Models;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace BE.Controllers
{
    [Route("api/v1/web/feedback")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }
        
        [HttpPost]
        [Route("create-feedback")]
        public async Task<ActionResult<Feedback>> CreateFeedback(CreateFeedbackDTO createFeedbackDto)
        {
            var feedback = await _feedbackService.CreateFeedbackAsync(createFeedbackDto);
            return CreatedAtAction(nameof(GetFeedbackById), new { id = feedback.Id }, feedback);
        }

        [HttpPut("update-feedback/{id}")]
        
        public async Task<ActionResult<Feedback>> UpdateFeedback(string id, UpdateFeedbackDTO updateFeedbackDto)
        {
            if (id != updateFeedbackDto.Id)
            {
                return BadRequest("ID mismatch");
            }

            try
            {
                var updatedFeedback = await _feedbackService.UpdateFeedbackAsync(updateFeedbackDto);
                return Ok(updatedFeedback);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Feedback not found");
            }
        }

        [HttpDelete("delete-feedback/{id}")]
        
        public async Task<ActionResult> DeleteFeedback(string id)
        {
            await _feedbackService.DeleteFeedbackAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        
        public async Task<ActionResult<Feedback>> GetFeedbackById(string id)
        {
            var feedback = await _feedbackService.GetFeedbackByIdAsync(id);
            if (feedback == null)
            {
                return NotFound("Feedback not found");
            }

            return Ok(feedback);
        }

        [HttpGet]
        
        public async Task<ActionResult<List<Feedback>>> GetAllFeedbacks()
        {
            var feedbacks = await _feedbackService.GetAllFeedbacksAsync();
            return Ok(feedbacks);
        }
    }
}
