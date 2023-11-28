using System;
using System.Collections.Generic;

namespace RoyalDelivery.Models.DBObjects
{
    public partial class Colet
    {
        public Guid IdColet { get; set; }
        public Guid IdDateLivrare { get; set; }
        public Guid IdInformatiiPlata { get; set; }
        public Guid IdLivrator { get; set; }
        public string? Awb { get; set; }
        public string? StareColet { get; set; }
        public string? LocatieDepozit { get; set; }

        public virtual DateLivrare IdDateLivrareNavigation { get; set; } = null!;
        public virtual InformatiiPlata IdInformatiiPlataNavigation { get; set; } = null!;
        public virtual Livrator IdLivratorNavigation { get; set; } = null!;
    }
}
