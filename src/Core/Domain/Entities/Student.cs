using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Student :BaseEntity
    {
        public decimal StudentNumber { get; set; }  
        public string FirstName { get; set; }       
        public string LastName { get; set; }        
        public decimal Class { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }


    }
}
