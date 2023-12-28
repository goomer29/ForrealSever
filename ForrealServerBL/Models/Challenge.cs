using System;
using System.Collections.Generic;

namespace ForrealServerBL.Models;

public partial class Challenge
{
    public int Id { get; set; }

    public int Difficult { get; set; }

    public string Text { get; set; } = null!;

    public virtual ICollection<UsersChallenge> UsersChallenges { get; set; } = new List<UsersChallenge>();
}
