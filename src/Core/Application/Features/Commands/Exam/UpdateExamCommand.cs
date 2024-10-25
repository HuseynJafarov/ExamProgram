using Application.Helpers.Result;
using MediatR;

namespace Application.Features.Commands.Exam
{
    public record UpdateExamCommand : IRequest<ServiceResult>
    {
        public int ExamId { get; set; }
        public string LessonCode { get; set; }
        public decimal StudentNumber { get; set; }
        public DateTime ExamDate { get; set; }
        public decimal Grade { get; set; }
    }
}