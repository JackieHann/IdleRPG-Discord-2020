using System;
using System.Collections.Generic;
using System.Text;

namespace IdleRPG_JH.Bots.Managers
{
    public struct Party
    {
        public Party(ulong id)
        {
            //Initialize with Member 
            MemberIDs = new List<ulong>(){ id };
        }

        const int maxPlayers = 4;
        public List<ulong> MemberIDs { get; private set; }
    }
    public sealed class PartyManager
    {
        //Singleton Implementation
        static PartyManager() { }
        private PartyManager() 
        {
            //Here we would load the parties somehow, JSON?
            ActiveParties = new List<Party>();
        }
        public static PartyManager Instance { get { return instance; } }
        private static readonly PartyManager instance = new PartyManager();

        private List<Party> ActiveParties;

        public string CreateParty(ulong id)
        {
            foreach (Party p in ActiveParties)
                if (p.MemberIDs.Contains(id))
                {
                    return "You are already in a party!";
                }

            ActiveParties.Add(new Party(id));
            return "Party Created";

        }

        public void JoinParty(ulong leaderID, ulong newcomerID)
        { 
        
        }

        public string LeaveParty(ulong id)
        {
            foreach (Party p in ActiveParties)
            {
                if (p.MemberIDs.Remove(id))
                {
                    if (p.MemberIDs.Count <= 0)
                    {
                        ActiveParties.Remove(p);
                        return "Disbanded Party";
                    }
                    else
                        return "Left Party";
                }
            }

            return "You arent in a party!";
        }
    
    }
}
