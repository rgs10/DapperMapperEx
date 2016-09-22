using System;
using System.Collections.Generic;

namespace ComplexObjectMapping
{
    public class Team
    {
        public Guid TeamId { get; set; }
        public string TeamName { get; set; }

        public IList<Player> Players { get; set; }
    }
}
