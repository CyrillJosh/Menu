using System;
using System.Collections.Generic;

namespace Menu.Models;

public partial class Dish
{
    public int DishId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public string? Category { get; set; }

    public byte[]? ImageData { get; set; }

    public string? ImageMimeType { get; set; }

    public bool IsAvailable { get; set; }

    public DateTime CreatedAt { get; set; }
}
