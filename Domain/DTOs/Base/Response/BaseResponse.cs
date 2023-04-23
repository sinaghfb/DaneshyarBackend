using Domain.Enums;

namespace Domain.DTOs.Base.Response
{
    public class BaseResponse
    {
        public ResponseStateEnum Status { get; set; }
        public string? Message { get; set; }
        public string? Description { get; set; }
    }
}
