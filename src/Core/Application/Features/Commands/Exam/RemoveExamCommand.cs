using Application.Helpers.Result;
using MediatR;

namespace Application.Features.Commands.Exam
{
    public record RemoveExamCommand : IRequest<ServiceResult>
    {
        public RemoveExamCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}