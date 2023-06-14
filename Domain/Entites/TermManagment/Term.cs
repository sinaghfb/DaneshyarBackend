using Domain.Entites.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites.TermManagment
{
    public class Term:BaseEntity
    {
        public Term()
        {
            TermCourseList = new List<TermCourse>();
        }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public int TermCount { get; set; }
        public string TermNo { get; set; }
        public string TermTitle { get; set; }
        public virtual IList<TermCourse> TermCourseList { get; set; }
    }
}
