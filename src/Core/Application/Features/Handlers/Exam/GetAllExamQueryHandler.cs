using Application.Abstractions.Repositories;
using Application.DTOs.Exam;
using Application.Features.Queries.Exam;
using Application.Helpers.Result;
using AutoMapper;
using MediatR;

namespace Application.Features.Handlers.Exam
{
    public class GetAllExamQueryHandler : IRequestHandler<GetAllExamQuery, List<ExamListDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllExamQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ExamListDTO>> Handle(GetAllExamQuery request, CancellationToken cancellationToken)
        {
            var exams = await _unitOfWork.Repository<Domain.Entities.Exam>().GetAll();
            var mappingExams = _mapper.Map<List<ExamListDTO>>(exams);
            return mappingExams;
        }
    }
}