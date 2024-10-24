using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Exam : BaseEntity
    {
        public string LessonCode { get; set; }      
        public decimal StudentNumber { get; set; }  
        public DateTime ExamDate { get; set; }     
        public decimal Grade { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual Lesson Lesson { get; set; }

    }
}
