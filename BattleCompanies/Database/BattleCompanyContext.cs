using BattleCompanies.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace BattleCompanies.Database
{
    public class BattleCompanyContext : DbContext
    {
        public BattleCompanyContext(DbContextOptions<BattleCompanyContext> options) : base(options)
            {
            }

        public BattleCompanyContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BattleCompanyDatabase;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        //OnModelCreating allows for explicit declaration of relationships
        //In Entity Framework Core, this is mostly useful for declaring explicit Many-to-Many relationships
        //As Enttiy Framework Core DOES NOT implicitly determine these based on Collection relationship fields
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Declare Many-to-Many for Factions and the Wargear that their heroes can select
            modelBuilder.Entity<FactionWargear>().HasKey(x => new { x.FactionID, x.WargearID });

            modelBuilder.Entity<FactionWargear>().HasOne(fw => fw.Wargear).WithMany(w => w.FactionWargears).HasForeignKey(fw => fw.WargearID);

            modelBuilder.Entity<FactionWargear>().HasOne(fw => fw.Faction).WithMany(f => f.FactionWargears).HasForeignKey(fw => fw.FactionID);

            //Declare Many-to-Many for Soldiers and the many Keywords that apply to them
            modelBuilder.Entity<SoldierKeywords>().HasKey(sk => new { sk.KeywordID, sk.SoldierID });

            modelBuilder.Entity<SoldierKeywords>().HasOne(sk => sk.Soldier).WithMany(s => s.SoldierKeywords).HasForeignKey(sk => sk.SoldierID);

            modelBuilder.Entity<SoldierKeywords>().HasOne(sk => sk.Keyword).WithMany(k => k.SoldierKeywords).HasForeignKey(sk => sk.KeywordID);

            //Declare Many-to-Many for Soldiers and the Wargear they have with them in the game
            modelBuilder.Entity<SoldierWargear>().HasKey(sw => new { sw.WargearID, sw.SoldierID });

            modelBuilder.Entity<SoldierWargear>().HasOne(sw => sw.Soldier).WithMany(s => s.SoldierWargears).HasForeignKey(sw => sw.SoldierID);

            modelBuilder.Entity<SoldierWargear>().HasOne(sw => sw.Wargear).WithMany(s => s.SoldierWargears).HasForeignKey(sw => sw.WargearID);
        }


        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Faction> Factions { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<Soldier> Soldiers { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Wargear> Wargears { get; set; }





    }
}
