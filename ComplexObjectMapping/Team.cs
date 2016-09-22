namespace ComplexObjectMapping
{
    using System;
    using System.Collections.Generic;

    public class Team
    {
        public Guid TeamId { get; set; }
        public string TeamName { get; set; }

        public IList<Player> Players { get; set; }
    }
}
