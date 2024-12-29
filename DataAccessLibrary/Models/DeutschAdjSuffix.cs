using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLibrary.Models;

public partial class DeutschAdjSuffix
{
    [Key]
    public Guid Oid { get; set; }

    public string? Gender { get; set; }

    public string? GermanCase { get; set; }

    public string? Type { get; set; }

    public string? Value { get; set; }
}
