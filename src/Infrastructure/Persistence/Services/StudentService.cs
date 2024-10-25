using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.DTOs.Student;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRepository<Student> _studentRepository;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task CreateAsync(StudentCreateAndUpdateDto Student)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<StudentListDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<StudentListDto>> SerachAsync(string? searchText)
        {
            throw new NotImplementedException();
        }

        public Task SoftDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, StudentCreateAndUpdateDto Student)
        {
            throw new NotImplementedException();
        }
    }
}
