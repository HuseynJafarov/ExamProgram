using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Lesson : BaseEntity
    {
        public string LessonCode { get; set; }  
        public string LessonName { get; set; }
        public decimal Class { get; set; }
        public string TeacherFirstName { get; set; }  
        public string TeacherLastName { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual Exam Exam { get; set; }

    }
}
