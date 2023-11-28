using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RoyalDelivery.Models.DBObjects;

public partial class ColetModel
{
    public Guid IdColet { get; set; }

    public Guid IdDateLivrare { get; set; }

    public Guid IdInformatiiPlata { get; set; }

    public Guid IdLivrator { get; set; }

    [StringLength(30, ErrorMessage = "Text prea lung(limita 30 de caractere)")]
    public string Awb { get; set; }

    [StringLength(30, ErrorMessage = "Text prea lung(limita 30 de caractere)")]
    public string StareColet { get; set; }

    [StringLength(30, ErrorMessage = "Text prea lung(limita 30 de caractere)")]
    public string LocatieDepozit { get; set; }

    public virtual DateLivrareModel IdDateLivrareNavigation { get; set; }

    public virtual InformatiiPlataModel IdInformatiiPlataNavigation { get; set; }

    public virtual LivratorModel IdLivratorNavigation { get; set; }
}
