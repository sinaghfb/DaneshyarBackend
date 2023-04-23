using System.ComponentModel;

namespace Domain.Enums
{
    public enum ObjectStateEnum
    {
        [Description("نامعلوم")]
        Unknown = 0,
        [Description("فعال")]
        Active = 1,
        [Description("غیرفعال")]
        Inactive = 2,
        [Description("آرشیو")]
        Archive = 3,
        [Description("خطا")]
        Error = 4,
        [Description("حذف شده")]
        Deleted= 5,
    }
}
