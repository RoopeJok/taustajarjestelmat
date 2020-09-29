using System;
using System.ComponentModel.DataAnnotations;
namespace GameWebApi
{
    public class NewItem
    {
        [EnumDataType(typeof(ItemType))]
        public ItemType type { get; set; }
        public int level { get; set; }
        public String Name { get; set; }
    }
}