using System.ComponentModel;

namespace Domain.Enums
{
    public enum EntranceYearEnum
    {
        [Description("نامعلوم")]
        None = 0,
        [Description("سال اول")]
        Year1 = 1,
        [Description("سال دوم")]
        Year2 = 2,
        [Description("سال سوم")]
        Year3 = 3,
        [Description("سال چهارم")]
        Year4 = 4,
    }
}
