using System;
using System.Collections.Generic;

namespace ForrealSever.Models;

public partial class Challange
{
    public int Id { get; set; }

    public int Difficult { get; set; }

    public string Text { get; set; } = null!;
}
