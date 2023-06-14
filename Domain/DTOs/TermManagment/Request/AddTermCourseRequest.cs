using Domain.Entites.CourseManagment;
using Domain.Enums;


namespace Domain.DTOs.TermManagment.Request
{
    public class AddTermCourseRequest
    {
        public string TeacherName { get; set; }
        public string StartHour { get; set; }
        public string EndHour { get; set; }
        public string Capacity { get; set; }
        public string CourseId { get; set; }
        public string Location { get; set; }
        public WeekdaysEnum Day { get; set; }
        public ExamDateEnum ExamDate { get; set; }
        public string ExamStartHour { get; set; }
        public string ExamEndHour { get; set; }
        public EntranceYearEnum EntraceYear { get; set; }
        public string TermId { get; set; }
    }
}
