using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RoyalDelivery.Models.DBObjects;

public partial class ColetDetailedModel
{ 

    [StringLength(30, ErrorMessage = "Text prea lung(limita 30 de caractere)")]
    public string Awb { get; set; }


    [StringLength(30, ErrorMessage = "Text prea lung(limita 30 de caractere)")]
    public string StareColet { get; set; }

    [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
    [DataType(DataType.Date)]
    public DateTime DataLivrare { get; set; }


    [StringLength(30, ErrorMessage = "Text prea lung(limita 30 de caractere)")]
    public string LocatieDepozit { get; set; }


    [StringLength(15, ErrorMessage = "Text prea lung(limita 15 de caractere)")]
    public string Nume { get; set; }


    [StringLength(15, ErrorMessage = "Text prea lung(limita 15 de caractere)")]
    public string Prenume { get; set; }


    [StringLength(25, ErrorMessage = "Text prea lung(limita 25 de caractere)")]
    public string? Email { get; set; }


    [StringLength(12, ErrorMessage = "Text prea lung(limita 12 de caractere)")]
    public string NumarTelefon { get; set; }


    [StringLength(20, ErrorMessage = "Text prea lung(limita 20 de caractere)")]
    public string Judet { get; set; }


    [StringLength(20, ErrorMessage = "Text prea lung(limita 20 de caractere)")]
    public string Oras { get; set; }


    [StringLength(20, ErrorMessage = "Text prea lung(limita 20 de caractere)")]
    public string Strada { get; set; }


    [StringLength(20, ErrorMessage = "Text prea lung(limita 20 de caractere)")]
    public string Numar { get; set; }


    [StringLength(100, ErrorMessage = "Text prea lung(limita 100 de caractere)")]
    public string? InformatiiAditionale { get; set; }


    [StringLength(10, ErrorMessage = "Text prea lung(limita 10 de caractere)")]
    public string TipPlata { get; set; }


    public float? SumaDatorata { get; set; }




}
