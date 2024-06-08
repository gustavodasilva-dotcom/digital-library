using System.ComponentModel;

namespace DigitalLibrary.Modules.Lendings.Domain.Enumerations;

public enum LendStatuses
{
    [Description("Open")]
    Open = 1,

    [Description("Late")]
    Late = 2,

    [Description("Concluded")]
    Concluded = 3,

    [Description("On queue")]
    OnQueue = 4,

    [Description("Cancelled")]
    Cancelled = 5
}
