using System;
using System.Collections.Generic;

namespace MVC.Data.Models;

public partial class File
{
    public int IdFile { get; set; }

    public string UrlPath { get; set; } = null!;

    public string Size { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual ICollection<ProductFile> ProductFiles { get; set; } = new List<ProductFile>();
}
