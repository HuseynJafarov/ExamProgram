﻿namespace Exam.Admin.Models.Exam
{
    public class ExamList
    {
        public int Id { get; set; }
        public string LessonCode { get; set; }
        public decimal StudentNumber { get; set; }
        public DateTime ExamDate { get; set; }
        public decimal Grade { get; set; }
    }
}
