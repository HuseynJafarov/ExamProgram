using Application.Features.Commands.Exam;
using Application.Features.Queries.Exam;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateExam(CreateExamCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateExam(UpdateExamCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveExam(RemoveExamCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllExams(GetAllExamQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }


    }
}