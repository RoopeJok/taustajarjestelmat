using System;
using System.Collections.Generic;
using System.Linq;
public class GetItems
{
    public Item[] getItems(Player player)
    {
        Item[] itemArray = new Item[player.Items.Count];
        for (int i = 0; i < player.Items.Count; i++)
        {
            itemArray[i] = player.Items[i];
        }
        return itemArray;
    }
    public Item[] getItemsWithLinq(Player player)
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