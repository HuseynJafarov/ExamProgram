using Application.Abstractions.Repositories;
using Application.Features.Commands.Exam;
using Application.Helpers.Result;
using Domain.Entities;
using MediatR;
using System.Diagnostics;

namespace Application.Features.Handlers.Exam
{
    public class CreateExamCommandHandler : IRequestHandler<CreateExamCommand, ServiceResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateExamCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResult> Handle(CreateExamCommand request, CancellationToken cancellationToken)
        {
            var exam = new Domain.Entities.Exam
            {
                CreateDate = DateTime.UtcNow.AddHours(4),
                LessonCode = request.LessonCode,
                StudentNumber = request.StudentNumber,
                ExamDate = request.ExamDate,
                Grade = request.Grade
            };

            await _unitOfWork.Repository<Domain.Entities.Exam>().Create(exam);
            await _unitOfWork.CommitAsync();

            return ServiceResult.Succeed("Exam created successfully.");

        }
    }
   
}