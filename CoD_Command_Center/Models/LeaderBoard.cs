using System;
using System.Collections.Generic;

namespace CoD_Command_Center.Models;

public partial class LeaderBoard
{
    public string UserId { get; set; } = null!;

    public int BoardRanking { get; set; }

    public int KillCount { get; set; }

    public int Level { get; set; }

    public string UserName { get; set; } = null!;

    public virtual User1 UserNameNavigation { get; set; } = null!;
}
