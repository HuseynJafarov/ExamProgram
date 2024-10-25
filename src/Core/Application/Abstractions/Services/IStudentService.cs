using Application.DTOs.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Services
{
    public interface IStudentService
    {
        Task CreateAsync(StudentCreateAndUpdateDto Student);
        Task<List<StudentListDto>> GetAllAsync();
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
        Task UpdateAsync(int id, StudentCreateAndUpdateDto Student);
        Task<List<StudentListDto>> SerachAsync(string? searchText);
    }
}
