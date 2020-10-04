using System;
using System.Collections.Generic;
namespace Project
{
    public class Player
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public int Level { get; set; }
        public bool IsBanned { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
