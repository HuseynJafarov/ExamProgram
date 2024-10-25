using Application.Abstractions.Repositories;
using Application.DTOs.Exam;
using Application.Features.Queries.Exam;
using Application.Helpers.Result;
using AutoMapper;
using MediatR;

namespace Application.Features.Handlers.Exam
{
    public class GetByIdExamQueryHandler : IRequestHandler<GetByIdExamQuery, ExamListDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetByIdExamQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ExamListDTO> Handle(GetByIdExamQuery request, CancellationToken cancellationToken)

        {
            var exam = await _unitOfWork.Repository<Domain.Entities.Exam>().GetById(request.Id);
            if (exam == null) return null;
            
            var mappingExam = _mapper.Map<ExamListDTO>(exam);
            return mappingExam;
        }
    }
}