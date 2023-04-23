using System.ComponentModel;

namespace Domain.Enums
{
    public enum CourseTypeEnum
    {
        [Description("نامعلوم")]
        None = 0,
        [Description("اصلی")]
        Main = 1,
        [Description("اختیاری")]
        Optional = 2,
        [Description("پایه")]
        Basic = 3,
        [Description("کهاد")]
        Kahad = 4
    }
}
