using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleCompanies.Models
{
    public class Company
    {

        public int CompanyID { get; set; }
        public string Title { get; set; }

        public int Size { get; set; }

        public int Influence { get; set; }

        public User CompUser { get; set; }

        public Campaign CompCampaign { get; set; }

        public Faction CompFaction { get; set; }


    }
}
