namespace ComplexObjectMapping
{
    using System;

    public class Player
    {
        //[Slapper.AutoMapper.Id]
        public Guid PlayerRef { get; set; }

        //[Slapper.AutoMapper.Id]
        public Guid TeamRef { get; set; }
        public string PlayerName { get; set; }
    }
}