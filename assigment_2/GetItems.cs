using System;
using System.Collections.Generic;
using System.Linq;
public class GetItems
{
    public Array getItems(Player player)
    {
        Array array = player.Items.ToArray();
        return array;
    }
    public Array getItemsWithLinq(Player player)
    {

        return player.Items.ToArray();
    }
    public Item FirstItem(Player player)
    {
        Item firstitem = player.Items[0];
        if (firstitem == null)
        {
            return null;
        }
        else
        {
            return firstitem;
        }

    }
    public Item FirstItemWithLinq(Player player)
    {
        return player.Items.FirstOrDefault();
    }

}