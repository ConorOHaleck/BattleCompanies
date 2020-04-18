using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleCompanies.Models
{
    public class Hero : Soldier
    {

        public byte Might { get; set; }

        public byte Will { get; set; }

        public byte Fate { get; set; }
    }


}
