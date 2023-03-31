namespace Domain.DTOs.BaseInfo.Request
{
    public class UpdateUserRequest
    {
        public string? PersonId { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }
        public string? FatherName { get; set; }
        public string? NationalNo { get; set; }
    }
}
