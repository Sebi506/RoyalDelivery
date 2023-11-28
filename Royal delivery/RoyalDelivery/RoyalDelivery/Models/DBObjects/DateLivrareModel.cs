using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RoyalDelivery.Models.DBObjects;

public partial class DateLivrareModel
{
    public Guid IdDateLivrare { get; set; }

    public Guid IdAdresaLivrare { get; set; }

    public Guid IdContactClient { get; set; }

    [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
    [DataType(DataType.Date)]
    public DateTime DataLivrare { get; set; }

    public virtual ICollection<ColetModel> Colets { get; set; } = new List<ColetModel>();

}
