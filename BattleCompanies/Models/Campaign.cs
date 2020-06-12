﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleCompanies.Models
{
    public class Campaign
    {

        public int CampaignID { get; set; }

        public string CampaignName { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
    }
}
