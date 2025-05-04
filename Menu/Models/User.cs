using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Menu.Models;

public partial class User
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Please provide a Username")]
    [MinLength(3, ErrorMessage = "Username must be greater than 2")]
    [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Username must not contain special characters")]
    public string Username { get; set; } = null!;

    [Required(ErrorMessage = "Please provide a Password")]
    [MinLength(6, ErrorMessage = "Password must be greater than 5")]
    public string Password { get; set; } = null!;

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
