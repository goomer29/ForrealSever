using System;
using System.Collections.Generic;

namespace ForrealServerBL.Models;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string UserName { get; set; } = null!;
    public string UserPswd { get; set; } = null!;
}
