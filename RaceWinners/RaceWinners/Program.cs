using System;
using System.Threading.Tasks;
using RaceWinners.Models;
using System.Collections.Generic;

namespace RaceWinners
{
    class Program
    {
        static async Task Main(string[] args)
        {
            DataService ds = new DataService();
 
            // Asynchronously retrieve the group (class) data
            var data = await ds.GetGroupRanksAsync();

            for (int i = 0; i < data.Count; i++)
            {
                // Combine the ranks to print as a list
                var ranks = String.Join(", ", data[i].Ranks);

                Console.WriteLine($"{data[i].Name} - [{ranks}]");
            }
            
            Console.WriteLine($"A score:{data[0].GroupRank}");
            Console.WriteLine($"B score:{data[1].GroupRank}");
            Console.WriteLine($"C score:{data[2].GroupRank}");
            Console.WriteLine($"D score:{data[3].GroupRank}");

            /*for (int i = 1; i <= data.Count; i++)
            {
                int hold = 0;
                if (data[i - 1].GroupRank > data[i].GroupRank)
                {
                    hold = data[i].GroupRank;
                    data[i].GroupRank = data[i - 1].GroupRank;
                    data[i - 1].GroupRank = hold;
                }
            } */
            
            for (int i = 1; i < data.Count; i++)
            {
                Group hold;
                if (data[i - 1].GroupRank > data[i].GroupRank)
                {
                    hold = data[i];
                    data[i] = data[i - 1];
                    data[i - 1] = hold;
                }
            }
            
            Console.WriteLine($"4th place:{data[0].GroupRank}");
            Console.WriteLine($"3rd place:{data[1].GroupRank}");
            Console.WriteLine($"2nd place:{data[2].GroupRank}");
            Console.WriteLine($"1st place:{data[3].GroupRank}");
            
            
            
        }
    }
}