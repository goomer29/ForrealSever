using System;
using System.Collections.Generic;

namespace ForrealServerBL.Models;

public partial class UsersChallenge
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int ChallengeId { get; set; }

    public string? Media { get; set; }

    public virtual Challenge Challenge { get; set; } = null!;

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

    public virtual User User { get; set; } = null!;
}
