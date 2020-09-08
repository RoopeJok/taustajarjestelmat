public class PlayerForAnotherGame : IPlayer
{
    public int Score { get; set; }

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