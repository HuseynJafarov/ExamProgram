using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Base.Abstraction
{
    public interface IBaseEntity<T>
    {
         int Id { get; set; }
         DateTime CreateDate { get; set; }
    }
}
