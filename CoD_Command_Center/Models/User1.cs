using System;
using System.Collections.Generic;

namespace CoD_Command_Center.Models;

public partial class User1
{
    public string UserName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public string NickName { get; set; } = null!;

    public int? KillCount { get; set; }

    public int? Level { get; set; }

    public string? Badge { get; set; }

    public decimal? KnockoutRatio { get; set; }

    public int? Ranking { get; set; }

    public virtual ICollection<LeaderBoard> LeaderBoards { get; set; } = new List<LeaderBoard>();

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
