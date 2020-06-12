using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BattleCompanies.Models
{
    public class Wargear
    {

        public int WargearID { get; set; }

        public virtual ICollection<SoldierWargear> SoldierWargears { get; set; }

        public virtual ICollection<FactionWargear> FactionWargears { get; set; }
    }
}
