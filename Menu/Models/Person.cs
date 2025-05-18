using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Menu.Models;

public partial class Person
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Please provide a Firstname")]
    public string Firstname { get; set; } = null!;

    [Required(ErrorMessage = "Please provide a Lastname")]
    public string Lastname { get; set; } = null!;

    [Required(ErrorMessage = "Please provide an Email")]
    public string Email { get; set; } = null!;

    public int UserId { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime? DateUpdated { get; set; }

    public string Role {  get; set; }

    public virtual User User { get; set; } = null!;
}
