using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleCompanies.Models
{
    public class FactionWargear
    {

        public int FactionID { get; set; }
        public int WargearID { get; set; }
        public Wargear Wargear { get; set; }

        public Faction Faction { get; set; }
    }
}
