using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleCompanies.Models
{
    public class Keyword
    {

        public int KeywordID { get; set; }

        public string KeywordText { get; set; }

        public virtual ICollection<Soldier> Soldiers { get; set; }
    }
}
