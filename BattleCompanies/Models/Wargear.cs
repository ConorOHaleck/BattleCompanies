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

        public string WargearName { get; set; }

        public bool TwoHanded { get; set; }

        public bool Bow { get; set; }

        public virtual ICollection<SoldierWargear> SoldierWargears { get; set; }

        public virtual ICollection<FactionWargear> FactionWargears { get; set; }

        public Wargear()
        {

        }

        public Wargear(string name)
        {
            WargearName = name;
            TwoHanded = false;
            Bow = false;

            SoldierWargears = new List<SoldierWargear>();
            FactionWargears = new List<FactionWargear>();
        }

        public Wargear(string name, bool twoH, bool bow)
        {
            WargearName = name;
            TwoHanded = twoH;
            Bow = bow;

            SoldierWargears = new List<SoldierWargear>();
            FactionWargears = new List<FactionWargear>();
        }
    }
}
