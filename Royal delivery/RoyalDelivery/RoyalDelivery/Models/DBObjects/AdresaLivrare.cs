using System;
using System.Collections.Generic;

namespace RoyalDelivery.Models.DBObjects
{
    public partial class AdresaLivrare
    {
        public AdresaLivrare()
        {
            DateLivrares = new HashSet<DateLivrare>();
        }

        public Guid IdAdresaLivrare { get; set; }
        public string? Judet { get; set; }
        public string? Oras { get; set; }
        public string? Strada { get; set; }
        public string? Numar { get; set; }
        public string? InformatiiAditionale { get; set; }

        public virtual ICollection<DateLivrare> DateLivrares { get; set; }
    }
}
