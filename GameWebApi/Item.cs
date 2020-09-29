using System;
using System.ComponentModel.DataAnnotations;
namespace GameWebApi
{
    public enum ItemType { Sword, Potion, Shield }
    public class Item
    {
        [Range(0, 99)]
        public int level { get; set; }
        [DateChecker]
        public DateTime creationtime;
        public Guid Id { get; set; }
        public ItemType type { get; set; }
        public String Name { get; set; }
    }
}
