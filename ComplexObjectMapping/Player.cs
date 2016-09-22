namespace ComplexObjectMapping
{
    using System;

    public class Player
    {
        public Guid PlayerId { get; set; }
        public Guid TeamID { get; set; }
        public string Name { get; set; }
    }
}