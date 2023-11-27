using System;
using System.Collections.Generic;

namespace CoD_Command_Center.Models;

public partial class Team
{
    public string TeamId { get; set; } = null!;

    public string TeamName { get; set; } = null!;

    public int Ranking { get; set; }

    public int NumTrophees { get; set; }

    public int Level { get; set; }

    public string Role { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public virtual User1 UserNameNavigation { get; set; } = null!;
}
