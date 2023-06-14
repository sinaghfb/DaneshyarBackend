using Domain.Entites.Base;
using Domain.Entites.TermManagment;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entites.CourseManagment
{
    public class Course:BaseEntity
    {
        public Course()
        {
            PreRequireds = new ();
            Requireds= new ();
            TermCourses=new ();
        }
        [Required]
        public int UnitCount { get; set; }
        [Required]
        public string CourseNo { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string CourseCode { get; set; }

        [Required]
        public CourseTypeEnum CourseType { get; set; }
        public virtual List<PreRequired> PreRequireds  { get; set; }
        public virtual List<PreRequired> Requireds { get; set; }
        public virtual List<TermCourse> TermCourses { get; set; }

    }
}
