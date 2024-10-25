using MediatR;

namespace Application.Features.Commands.Exam
{
    public record RemoveExamCommand : IRequest
    {
        public RemoveExamCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}