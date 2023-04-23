using System.ComponentModel;

namespace Domain.Enums
{
    public enum AccessLevelEnum
    {
        [Description("هیچکدام")]
        None = 0,
        [Description("مدیر گروه")]
        Level1 = 1,
        [Description("استاد")]
        Level2 = 2,
        [Description("دانشجو")]
        Level3 = 3,
        [Description("کترل کلاس")]
        Level4 = 4,
        [Description("نامعلوم")]
        Unknown = 5
    }
}
