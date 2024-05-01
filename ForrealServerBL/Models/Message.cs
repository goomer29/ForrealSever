using System;
using System.Collections.Generic;

namespace ForrealServerBL.Models;

public partial class Message
{
    public int Id { get; set; }

    public int UserChId { get; set; }

    public int UserSentId { get; set; }

    public string? Message1 { get; set; }

    public DateTime? Time { get; set; }

    public virtual UsersChallenge UserCh { get; set; } = null!;

    public virtual User UserSent { get; set; } = null!;
}
