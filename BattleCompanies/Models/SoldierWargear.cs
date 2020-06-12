using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleCompanies.Models
{
    public class SoldierWargear
    {

        public int SoldierID { get; set; }
        public int WargearID { get; set; }
        public Soldier Soldier { get; set; }
        public Wargear Wargear { get; set; }
    }
}
