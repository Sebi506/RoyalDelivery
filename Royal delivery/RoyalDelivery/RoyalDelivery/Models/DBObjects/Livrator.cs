using System;
using System.Collections.Generic;

namespace RoyalDelivery.Models.DBObjects
{
    public partial class Livrator
    {
        public Livrator()
        {
            Colets = new HashSet<Colet>();
        }

        public Guid IdLivrator { get; set; }
        public string? Nume { get; set; }
        public string? Prenume { get; set; }
        public string? JudetActivitate { get; set; }

        public virtual ICollection<Colet> Colets { get; set; }
    }
}
