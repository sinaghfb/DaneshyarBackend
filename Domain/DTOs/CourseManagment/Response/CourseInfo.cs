
using Domain.DTOs.Base.Response;
using Domain.Enums;

namespace Domain.DTOs.CourseManagment.Response
{
    public class CourseInfo
    {
        public CourseInfo()
        {
            PreRequireds = new();
            CourseType = new();
        }
        public string CourseName { get; set; }
        public string CourseNo { get; set; }
        public string CourseCode { get; set; }
        public string CourseId { get; set; }
        public int UnitCount { get; set; }
        public List<SelectModel> PreRequireds { get; set; }
        public SelectModel CourseType { get; set; }
    }
}
