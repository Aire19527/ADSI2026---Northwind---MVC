using System;
using System.Collections.Generic;

namespace MVC.Data.Models;

public partial class ProductFile
{
    public int Id { get; set; }

    public int IdProduct { get; set; }

    public int IdFile { get; set; }

    public virtual File IdFileNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
