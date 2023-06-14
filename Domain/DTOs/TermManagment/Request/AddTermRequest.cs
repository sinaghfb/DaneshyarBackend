namespace Domain.DTOs.TermManagment.Request
{
    public class AddTermRequest
    {
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public int TermCount { get; set; }
        public string TermNo { get; set; }
        public string TermTitle { get; set; }
    }
}
