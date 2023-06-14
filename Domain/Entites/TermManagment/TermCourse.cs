using Domain.Entites.Base;
using Domain.Entites.CourseManagment;
using Domain.Enums;

namespace Domain.Entites.TermManagment
{
    public class TermCourse:BaseEntity
    {
        public TermCourse()
        {
            TheCourse = new Course();
            TheTerm = new Term();
        }
        public string TermCourseNo { get; set; }
        public string TeacherName { get; set; }
        public string StartHour { get; set; }
        public string EndHour { get; set; }
        public string Capacity { get; set; }
        public virtual Term TheTerm { get; set; }
        public string TermId { get; set; }
        public string CourseId { get; set; }
        public virtual Course  TheCourse{ get; set; }
        public string Location { get; set; }
        public WeekdaysEnum Day { get; set; }
        public ExamDateEnum ExamDate { get; set; }
        public string ExamStartHour { get; set; }
        public string ExamEndHour { get; set; }
        public EntranceYearEnum EntraceYear { get; set; }
    }
}
