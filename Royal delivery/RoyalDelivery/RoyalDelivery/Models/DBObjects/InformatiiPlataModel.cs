using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RoyalDelivery.Models.DBObjects;

public partial class InformatiiPlataModel
{
    public Guid IdInformatiiPlata { get; set; }

    [StringLength(10, ErrorMessage = "Text prea lung(limita 10 de caractere)")]
    public string TipPlata { get; set; }

    public float? SumaDatorata { get; set; }

}
