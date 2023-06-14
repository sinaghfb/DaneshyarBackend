using System.ComponentModel;

namespace Domain.Enums
{
    public enum WeekdaysEnum
    {
        [Description("نامعلوم")]
        None = 0,
        [Description("شنبه")]
        Saturday = 1,
        [Description("یک شنبه")]
        Sunday = 2,
        [Description("دو شنبه")]
        Monday = 3,
        [Description("سه شنبه")]
        Tuesday = 4,
        [Description("چهار شنبه")]
        Wednesday = 5,
        [Description("پنج شنبه")]
        Thursday = 6,
        [Description("جمعه")]
        Friday = 7
    }
}
