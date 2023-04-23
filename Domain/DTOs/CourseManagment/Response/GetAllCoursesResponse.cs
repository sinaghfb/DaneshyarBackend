using Domain.DTOs.Base.Response;

namespace Domain.DTOs.CourseManagment.Response
{
    public class GetAllCoursesResponse:BaseResponse
    {
        public GetAllCoursesResponse()
        {
            Courses = new List<CourseInfo>();
        }
        public IList<CourseInfo> Courses { get; set; }
    }
}
