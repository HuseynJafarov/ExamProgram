using Application.Features.Commands.Exam;
using Application.Features.Queries.Exam;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ExamController> _logger;

        public ExamController(IMediator mediator, ILogger<ExamController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateExam(CreateExamCommand command)
        {
         
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> UpdateExam(UpdateExamCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> RemoveExam(int id)
        {
            var command = new RemoveExamCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllExams()
        {
            try
            {
                var getallQuery = new GetAllExamQuery();
                var result = await _mediator.Send(getallQuery);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching Exam.");
                return StatusCode(500, "Internal server error.");
            }

        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetExam(int id)
        {
            try
            {
                var query = new GetByIdExamQuery(id);
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching Exam.");
                return StatusCode(500, "Internal server error.");
            }

        }


    }
}