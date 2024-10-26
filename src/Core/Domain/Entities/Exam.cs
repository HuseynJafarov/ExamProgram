using Domain.Base;

namespace Domain.Entities
{
    public class Exam : BaseEntity
    {
        public string LessonCode { get; set; }
        public decimal StudentNumber { get; set; }
        public DateTime ExamDate { get; set; }
        public decimal Grade { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public int LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }
    }
}