namespace Exam.Admin.Models.Exam
{
    public class ExamCreate
    {
        public string LessonCode { get; set; }
        public decimal StudentNumber { get; set; }
        public DateTime ExamDate { get; set; }
        public decimal Grade { get; set; }
        public int LessonId { get; set; }
    }
}
