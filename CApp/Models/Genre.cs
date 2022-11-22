﻿using System;
using System.Collections.Generic;

namespace TVChannelProject.Models;

public partial class Genre
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Program> Programs { get; } = new List<Program>();
}
