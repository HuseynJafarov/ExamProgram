using Application.DTOs.Lesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Services
{
    public interface ILessonService
    {
        Task CreateAsync(LessonCreateAndUpdateDto lesson);
        Task<List<LessonListDto>> GetAllAsync();
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
        Task UpdateAsync(int id, LessonCreateAndUpdateDto lesson);
        Task<List<LessonListDto>> SerachAsync(string? searchText);
    }
}
