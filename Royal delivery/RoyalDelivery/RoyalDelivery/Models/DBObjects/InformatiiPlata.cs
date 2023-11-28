using System;
using System.Collections.Generic;

namespace RoyalDelivery.Models.DBObjects
{
    public partial class InformatiiPlata
    {
        public InformatiiPlata()
        {
            Colets = new HashSet<Colet>();
        }

        public Guid IdInformatiiPlata { get; set; }
        public string? TipPlata { get; set; }
        public float? SumaDatorata { get; set; }

        public virtual ICollection<Colet> Colets { get; set; }
    }
}
