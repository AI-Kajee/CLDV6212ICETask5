using System;
using System.Collections.Generic;

namespace CoD_Command_Center.Models;

public partial class NewsAndUpdate
{
    public int AId { get; set; }

    public string? ArticleName { get; set; }

    public string? ArticleDescription { get; set; }

    public DateOnly? ACreatedAt { get; set; }

    public DateOnly? AUpdatedAt { get; set; }
}
