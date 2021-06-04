using System.Collections.Generic;

namespace PierresMarket.Models
{
  public class Treat
    {
        public Treat()
        {
            this.JoinEntities = new HashSet<TreatFlavor>();
        }

        public int TreatId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<TreatFlavor> JoinEntities { get; set; }
    }
}