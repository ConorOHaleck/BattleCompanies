using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleCompanies.Models
{
    public class Soldier
    {
        public int SoldierID { get; set; }

        public string SoldierName { get; set; }

        public Int16 PointCost { get; set; }

        public byte Movement { get; set; }

        public byte Fight { get; set; }

        public byte Shoot { get; set; }

        public byte Strength { get; set; }

        public byte Defense { get; set; }

        public byte Attacks { get; set; }

        public byte Wounds { get; set; }

        public byte Courage { get; set; }

        public byte Might { get; set; }

        public byte Will { get; set; }

        public byte Fate { get; set; }

        public byte Experience { get; set; }

        public Company Company { get; set; }

        public BaseClass SoldierClass { get; set; }

        public virtual ICollection<SoldierWargear> SoldierWargears { get; set; }

        public virtual ICollection<SoldierKeywords> SoldierKeywords { get; set; }
    }
}
