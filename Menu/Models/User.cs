using System;
using System.Collections.Generic;

namespace Menu.Models;

public partial class User
{
    public int Id { get; set; }

    public string Role { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
