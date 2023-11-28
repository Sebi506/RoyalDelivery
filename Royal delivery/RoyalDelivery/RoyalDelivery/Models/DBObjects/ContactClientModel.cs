using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RoyalDelivery.Models.DBObjects;

public partial class ContactClientModel
{
    public Guid IdContactClient { get; set; }

    [StringLength(15, ErrorMessage = "Text prea lung(limita 15 de caractere)")]
    public string Nume { get; set; }

    [StringLength(15, ErrorMessage = "Text prea lung(limita 15 de caractere)")]
    public string Prenume { get; set; }

    [StringLength(25, ErrorMessage = "Text prea lung(limita 25 de caractere)")]
    public string? Email { get; set; }

    [StringLength(12, ErrorMessage = "Text prea lung(limita 12 de caractere)")]
    public string NumarTelefon { get; set; }

}
