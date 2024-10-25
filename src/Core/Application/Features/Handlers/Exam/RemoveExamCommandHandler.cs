using Application.Abstractions.Repositories;
using Application.Features.Commands.Exam;
using Application.Helpers.Result;
using MediatR;

namespace Application.Features.Handlers.Exam
{
    public class RemoveExamCommandHandler : IRequestHandler<RemoveExamCommand, ServiceResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveExamCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResult> Handle(RemoveExamCommand request, CancellationToken cancellationToken)
        {
            var exam = await _unitOfWork.Repository<Domain.Entities.Exam>().GetById(request.Id);
            if (exam == null) return ServiceResult.Failed("Exam not found.");

            await _unitOfWork.Repository<Domain.Entities.Exam>().Delete(exam);
            await _unitOfWork.CommitAsync();
            return ServiceResult.Succeed("Exam deleted successfully.");
        }
    }
}