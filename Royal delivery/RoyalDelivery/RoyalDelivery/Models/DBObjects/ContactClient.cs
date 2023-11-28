using System;
using System.Collections.Generic;

namespace RoyalDelivery.Models.DBObjects
{
    public partial class ContactClient
    {
        public ContactClient()
        {
            DateLivrares = new HashSet<DateLivrare>();
        }

        public Guid IdContactClient { get; set; }
        public string? Nume { get; set; }
        public string? Prenume { get; set; }
        public string? Email { get; set; }
        public string? NumarTelefon { get; set; }

        public virtual ICollection<DateLivrare> DateLivrares { get; set; }
    }
}
