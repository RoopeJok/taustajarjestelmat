using System;
using System.Collections.Generic;
public class Player : IPlayer
{
    public Guid Id { get; set; }
    public int Score { get; set; }
    public List<Item> Items { get; set; }
    public int CompareScore(Player player)
    {
        if (player == null)
        {
            return 1;
        }
        else
        {
            return this.Score.CompareTo(player.Score);
        }
    }
}
static class GetHighestLevelItem
{
    public static int getHighestLevelItem(this Player value, List<Item> list)
    {
        if (value.Items.Count == 0)
        {
            throw new InvalidOperationException("Empty list");
        }
        int highestLevel = int.MinValue;
        foreach (Item item in list)
        {
            if (item.Level > highestLevel)
            {
                highestLevel = item.Level;
            }
        }
        return highestLevel;
    }

}
