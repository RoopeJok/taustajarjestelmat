using System;
using System.Collections.Generic;

namespace assigment_2
{
    public class Program
    {

        public static void ProcessEachItem(Player player, Action<Item> process)
        {

            player.Items.ForEach(process);
        }


        public static void PrintItem(Item item)
        {
            Console.WriteLine(item.Id);
            Console.WriteLine(item.Level);
        }
        static void Main(string[] args)
        {

            Item item;
            var player = new Player[10];
            List<Player> players = new List<Player>();
            List<PlayerForAnotherGame> playersForAnotherGames = new List<PlayerForAnotherGame>();
            var guids = new HashSet<Guid>();
            Random random = new Random();
            for (int i = 0; i < player.Length; i++)
            {
                Guid guid = Guid.NewGuid();
                player[i] = new Player();
                int score = random.Next(1000000);
                if (guids.Contains(guid))
                {
                    Console.WriteLine("There is Dublicate");
                }
                else
                {
                    player[i].Id = guid;
                }
                players.Add(new Player() { Score = score });
                playersForAnotherGames.Add(new PlayerForAnotherGame() { Score = score });
                player[i].Score = random.Next(1000000);
                player[i].Items = new List<Item>();
                Guid itemguid = Guid.NewGuid();
                item = new Item();
                item.Id = itemguid;
                item.Level = random.Next(1000000);
                player[i].Items.Add(item);
            }
            Game<Player> game = new Game<Player>(players);
            Game<PlayerForAnotherGame> antherGame = new Game<PlayerForAnotherGame>(playersForAnotherGames);
            Player[] top10players = game.GetTop10Players();
            PlayerForAnotherGame[] top10AnotherGame = antherGame.GetTop10Players();
            foreach (Player play in top10players)
            {
                Console.WriteLine(play.Score);
            }
            foreach (PlayerForAnotherGame play in top10AnotherGame)
            {
                Console.WriteLine(play.Score);
            }
            GetItems items = new GetItems();
            Action<Item> proces = PrintItem;
            Console.WriteLine(player[0].getHighestLevelItem(player[0].Items));
            Console.WriteLine(items.getItemsWithLinq(player[0]));
            Console.WriteLine(items.getItems(player[0]));
            Console.WriteLine(items.FirstItem(player[0]).Level);
            Console.WriteLine(items.FirstItemWithLinq(player[0]).Level);
            Action<Player, Action<Item>> process = (player, process) =>
            {
                player.Items.ForEach(process);
            };
            Action<Item> printitem = (item) => Console.WriteLine(item.Id + "\n" + item.Level);
            ProcessEachItem(player[0], proces);
            process(player[0], printitem);
        }
    }
}
