using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleCompanies.Models
{
    public class BaseClass
    {

        public int BaseClassID { get; set; }

        public string TypeName { get; set; }

        public Faction AssociatedFaction { get; set; }


    }
}
