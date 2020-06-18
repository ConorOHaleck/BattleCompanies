using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleCompanies.Models
{
    public class CampaignViewModel
    {
        public IEnumerable<Company> Companies { get; set; }

        public IEnumerable<Faction> Factions { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
