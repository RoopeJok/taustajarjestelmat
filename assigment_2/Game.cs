using System.Collections.Generic;
using System.Linq;



public class Game<T> where T : IPlayer
{
    private List<T> _players;

    public Game(List<T> players)
    {
        _players = players;
    }

    public T[] GetTop10Players()
    {
        T[] godPlayers = new T[10];
        _players = _players.OrderBy(player => player.Score).ToList();
        int bestplayers = 0;
        for (int i = _players.Count - 1; bestplayers < 10; bestplayers++, i--)
        {
            godPlayers[bestplayers] = _players[i];
        }
        return godPlayers;
    }
}
