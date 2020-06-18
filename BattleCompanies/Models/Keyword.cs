using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleCompanies.Models
{
    public class Keyword
    {

        public static readonly string HERO_KEYWORD = "HERO";
        public static readonly string INF_KEYWORD = "INFANTRY";
        public static readonly string CAV_KEYWORD = "CAVALRY";
        public static readonly string BEAST_KEYWORD = "BEAST";
        public static readonly string MAN_KEYWORD = "MAN";
        public static readonly string HOBBIT_KEYWORD = "HOBBIT";
        public static readonly string ELF_KEYWORD = "ELF";
        public static readonly string DWARF_KEYWORD = "DWARF";
        public static readonly string ORC_KEYWORD = "ORC";
        public static readonly string URUK_KEYWORD = "URUK";

        public int KeywordID { get; set; }

        public string KeywordText { get; set; }

        public virtual ICollection<SoldierKeywords> SoldierKeywords { get; set; }

        public Keyword() { }

        public Keyword(String theKeyword)
        {
            KeywordText = theKeyword;
        }
    }
}
