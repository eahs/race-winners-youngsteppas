﻿using System.Collections.Generic;
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;

namespace RaceWinners.Models
{
    /// <summary>
    /// Stores all the data associated with a group of runners
    /// </summary>
    public class Group
    {
        // Name of group
        public string Name { get; set; }

        /// <summary>
        /// Each spot in the list represents the overall rank of finish place in this group
        /// (not the overall race).  So if index 0 contains a 4, then the first runner in this
        /// group placed 4th overall.  
        /// </summary>
        public List<int> Ranks { get; set; }
        
        
        //Calculates Group Rank by assigning point value to each position in race and averaging
        public int GroupRank
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < Ranks.Count; i++)
                {
                    sum += (75 - Ranks[i]);
                }
                return (sum / Ranks.Count);                
            }

        }

        
    }
}