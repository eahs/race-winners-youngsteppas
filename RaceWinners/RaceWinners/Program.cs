using System;
using System.Threading.Tasks;

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

            for (int i = 1; i <= data.Count; i++)
            {
                int hold = 0;
                if (data[i - 1].GroupRank > data[i].GroupRank)
                {
                    hold = data[i].GroupRank;
                    data[i].GroupRank = data[i - 1].GroupRank;
                    data[i - 1].GroupRank = hold;
                }
            }
            Console.WriteLine($"{data[3].GroupRank}");
            
            
        }
    }
}