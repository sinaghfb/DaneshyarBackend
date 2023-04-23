using Domain.DTOs.Base.Response;
using Domain.Enums;

namespace Domain.DTOs.CourseManagment.Response
{
    public class GetCourseResponse:BaseResponse
    {
        public GetCourseResponse()
        {
            DetailInfo = new();
        }
        public CourseInfo DetailInfo { get; set; }
    }
}
