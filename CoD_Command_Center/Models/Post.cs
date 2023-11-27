using System;
using System.Collections.Generic;

namespace CoD_Command_Center.Models;

public partial class Post
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? BlogBody { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public DateOnly? UpdatedAt { get; set; }
}
