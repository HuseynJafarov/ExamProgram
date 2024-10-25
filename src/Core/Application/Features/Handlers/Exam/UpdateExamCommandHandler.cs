using Application.Abstractions.Repositories;
using Application.Features.Commands.Exam;
using Application.Helpers.Result;
using MediatR;

namespace Application.Features.Handlers.Exam
{
    public class UpdateExamCommandHandler : IRequestHandler<UpdateExamCommand, ServiceResult>
    {
        private IUnitOfWork _unitOfWork;

        public UpdateExamCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResult> Handle(UpdateExamCommand request, CancellationToken cancellationToken)
        {
            var exam = await _unitOfWork.Repository<Domain.Entities.Exam>().GetById(request.ExamId);

            if (exam == null)
                return ServiceResult.Failed("Exam not found.");

            exam.LessonCode = request.LessonCode;
            exam.StudentNumber = request.StudentNumber;
            exam.ExamDate = request.ExamDate;
            exam.Grade = request.Grade;

            await _unitOfWork.Repository<Domain.Entities.Exam>().Update(exam);
            await _unitOfWork.CommitAsync();

            return ServiceResult.Succeed("Exam updated successfully.");
        }
    }
}