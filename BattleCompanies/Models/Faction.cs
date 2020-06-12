using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace BattleCompanies.Models
{
    public class Faction
    {
        public int FactionID { get; set; }

        public string FactionName { get; set; }

        public virtual ICollection<FactionWargear> FactionWargears { get; set; }
    }
}
