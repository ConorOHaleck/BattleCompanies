using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleCompanies.Models
{
    public class Wargear
    {

        public int WargearID { get; set; }

        public virtual ICollection<Soldier> Soldiers { get; set; }
    }
}
