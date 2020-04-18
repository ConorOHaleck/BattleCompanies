using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleCompanies.Models
{
    public class User
    {

        public int UserID { get; set; }

        public virtual ICollection<Campaign> Campaigns { get; set; }
    }
}
