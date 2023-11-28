using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RoyalDelivery.Models.DBObjects;

public partial class LivratorModel
{
    public Guid IdLivrator { get; set; }

    [StringLength(30, ErrorMessage = "Text prea lung(limita 30 de caractere)")]
    public string Nume { get; set; }

    [StringLength(30, ErrorMessage = "Text prea lung(limita 30 de caractere)")]
    public string Prenume { get; set; }

    [StringLength(20, ErrorMessage = "Text prea lung(limita 20 de caractere)")]
    public string JudetActivitate { get; set; }

}
