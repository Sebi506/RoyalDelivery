using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RoyalDelivery.Models.DBObjects;

public partial class AdresaLivrareModel
{
    public Guid IdAdresaLivrare { get; set; }

    [StringLength(20,ErrorMessage = "Text prea lung(limita 20 de caractere)")]
    public string Judet { get; set; }

    [StringLength(20, ErrorMessage = "Text prea lung(limita 20 de caractere)")]
    public string Oras { get; set; }

    [StringLength(20, ErrorMessage = "Text prea lung(limita 20 de caractere)")]
    public string Strada { get; set; }

    [StringLength(20, ErrorMessage = "Text prea lung(limita 20 de caractere)")]
    public string Numar { get; set; }

    [StringLength(100, ErrorMessage = "Text prea lung(limita 100 de caractere)")]
    public string? InformatiiAditionale { get; set; }

    public virtual ICollection<DateLivrareModel> DateLivrares { get; set; } = new List<DateLivrareModel>();
}
