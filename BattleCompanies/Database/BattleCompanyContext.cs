using BattleCompanies.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BattleCompanies.Database
{
    public class BattleCompanyContext : DbContext
    {
        public BattleCompanyContext() : base("BattleCompanyContext")
            {
            }

        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Faction> Factions { get; set; }
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<Soldier> Soldiers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Wargear> Wargears { get; set; }

        public DbSet<Warrior> Warriors { get; set; }

    }
}
