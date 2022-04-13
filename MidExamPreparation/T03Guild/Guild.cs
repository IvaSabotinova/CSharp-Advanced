using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        //private List<Player> roster;

        public List<Player> Roster { get; set; }
        
        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Roster = new List<Player>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count => Roster.Count;

        public void AddPlayer(Player player)
        {
            if (Roster.Count < Capacity)
            {
                Roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            if (Roster.Any(x=>x.Name == name))
            {
                Player playerToRemove = Roster.First(x => x.Name == name);
                Roster.Remove(playerToRemove);
                return true;
            }

            return false;
        }
       

        public void PromotePlayer(string name)
        {
            Player playerToPromote = Roster.First(x => x.Name == name);
            if (playerToPromote.Rank != "Member")
            {
                playerToPromote.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            Player playerToDemote = Roster.First(x => x.Name == name);
            if (playerToDemote.Rank != "Trial")
            {
                playerToDemote.Rank = "Trial";
            }
        }
       
        public Player[] KickPlayersByClass(string clas)
        {
            Player[] playersToRemoveByClass = Roster.FindAll(x => x.Class == clas).ToArray();
            Roster.RemoveAll(x => x.Class == clas);
            return playersToRemoveByClass;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");
            foreach (Player player in Roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
        
    }
}
