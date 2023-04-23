using Domain.Entites.Base;


namespace Domain.Entites.CourseManagment
{
    public class PreRequired:BaseEntity
    {
        public PreRequired()
        {
            RequiredCourse = new();
            PreRequiredCourse= new();
        }
        public virtual Course RequiredCourse { get; set; }
        public string RequiredCourseId { get; set; }
        public virtual Course PreRequiredCourse { get; set; }
        public string PreRequiredCourseId { get; set; }
    }
}
