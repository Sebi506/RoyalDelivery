using System;
using System.Collections.Generic;

namespace RoyalDelivery.Models.DBObjects
{
    public partial class DateLivrare
    {
        public DateLivrare()
        {
            Colets = new HashSet<Colet>();
        }

        public Guid IdDateLivrare { get; set; }
        public Guid IdAdresaLivrare { get; set; }
        public Guid IdContactClient { get; set; }
        public DateTime DataLivrare { get; set; }

        public virtual AdresaLivrare IdAdresaLivrareNavigation { get; set; } = null!;
        public virtual ContactClient IdContactClientNavigation { get; set; } = null!;
        public virtual ICollection<Colet> Colets { get; set; }
    }
}
