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
            
            //Displays Group Ranks for all Groups
            Console.WriteLine($"A score:{data[0].GroupRank}");
            Console.WriteLine($"B score:{data[1].GroupRank}");
            Console.WriteLine($"C score:{data[2].GroupRank}");
            Console.WriteLine($"D score:{data[3].GroupRank}");
            
            //Insertion sort algorithm to rank each Group
            Group hold;
            int j;
            for (int i = 1; i < data.Count; i++)
            {
                hold = data[i];
                j = i - 1;
                while (j >= 0 && (data[j].GroupRank > hold.GroupRank))
                {
                    data[j + 1] = data[j];
                    j = j - 1;
                }

                data[j + 1] = hold;
            }
            
            //Write sorted Groups to console
            Console.WriteLine($"4th place:{data[0].Name}, {data[0].GroupRank}");
            Console.WriteLine($"3rd place:{data[1].Name}, {data[1].GroupRank}");
            Console.WriteLine($"2nd place:{data[2].Name}, {data[2].GroupRank}");
            Console.WriteLine($"1st place:{data[3].Name}, {data[3].GroupRank}");
            
            
            
        }
    }
}