using System;
using System.Collections.Generic;

namespace ExpenditureTracker.Models;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public byte[] Password { get; set; } = null!;

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
