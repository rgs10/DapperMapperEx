using System;

namespace ComplexObjectMapping
{
    public class Player
    {
        public Guid PlayerId { get; set; }
        public Guid TeamID { get; set; }
        public string Name { get; set; }
    }
}