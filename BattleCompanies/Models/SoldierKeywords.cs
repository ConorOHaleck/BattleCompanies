using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleCompanies.Models
{
    public class SoldierKeywords
    {

        public int SoldierID { get; set; }

        public int KeywordID { get; set; }

        public Soldier Soldier { get; set; }
        public Keyword Keyword { get; set; }

    }
}
