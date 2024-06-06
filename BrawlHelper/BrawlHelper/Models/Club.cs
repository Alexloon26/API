﻿namespace BrawlHelper.Models
{
    public class ClubMember
    {
        public string Tag { get; set; }
        public string Name { get; set; }
        public int Trophies { get; set; }
    }

    public class Club
    {
        public string Tag { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Trophies { get; set; }
        public int RequiredTrophies { get; set; }
        public List<ClubMember> Members { get; set; }

        public Club()
        {
            Members = new List<ClubMember>();
        }
    }
}