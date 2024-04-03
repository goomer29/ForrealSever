using System;
using System.Collections.Generic;

namespace ForrealServerBL.Models;

public partial class Friend
{
    public int Id { get; set; }

    public int User1Id { get; set; }

    public int User2Id { get; set; }

    public virtual User User1 { get; set; } = null!;

    public virtual User User2 { get; set; } = null!;
}
