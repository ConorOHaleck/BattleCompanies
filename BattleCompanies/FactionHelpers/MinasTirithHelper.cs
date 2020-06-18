using BattleCompanies.Database;
using BattleCompanies.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BattleCompanies.FactionHelpers
{
    public static class MinasTirithHelper
    {
        public static async void AddDefaultCompany(BattleCompanyContext context, Company newCompany)
        {
            List<Wargear> wargears = await context.Wargears.ToListAsync();
            List<Keyword> keywords = await context.Keywords.ToListAsync();
            var gondor = context.Factions.FirstOrDefaultAsync(o => o.FactionName == "Minas Tirith");

            List<Soldier> defaultGuys = new List<Soldier>();

            for(int i = 0; i < 6; i++)
            {
                defaultGuys.Add(new Soldier()
                {
                    Movement = 6,
                    Fight = 3,
                    Shoot = 4,
                    Strength = 3,
                    Defense = 3,
                    Attacks = 1,
                    Wounds = 1,
                    Courage = 3,
                    Company = newCompany
                });
            }



            foreach (Soldier guy in defaultGuys)
            {
                guy.SoldierKeywords.Add(new SoldierKeywords()
                {
                    Keyword = keywords.FirstOrDefault(o => o.KeywordText == Keyword.INF_KEYWORD),
                    Soldier = guy
                });

                guy.SoldierKeywords.Add(new SoldierKeywords()
                {
                    Keyword = keywords.FirstOrDefault(o => o.KeywordText == Keyword.MAN_KEYWORD),
                    Soldier = guy
                });

                guy.SoldierWargears.Add(new SoldierWargear()
                {
                    Wargear = wargears.FirstOrDefault(o => o.WargearName == "Heavy Armor"),
                    Soldier = guy
                });

                guy.SoldierWargears.Add(new SoldierWargear()
                {
                    Wargear = wargears.FirstOrDefault(o => o.WargearName == "Sword"),
                    Soldier = guy
                });
            }



            defaultGuys[0].SoldierWargears.Add(new SoldierWargear()
            {
                Wargear = wargears.FirstOrDefault(o => o.WargearName == "Shield"),
                Soldier = defaultGuys[0]
            });

            defaultGuys[1].SoldierWargears.Add(new SoldierWargear()
            {
                Wargear = wargears.FirstOrDefault(o => o.WargearName == "Shield"),
                Soldier = defaultGuys[1]
            });

            defaultGuys[2].SoldierWargears.Add(new SoldierWargear()
            {
                Wargear = wargears.FirstOrDefault(o => o.WargearName == "Spear"),
                Soldier = defaultGuys[2]
            });

            defaultGuys[3].SoldierWargears.Add(new SoldierWargear()
            {
                Wargear = wargears.FirstOrDefault(o => o.WargearName == "Spear"),
                Soldier = defaultGuys[3]
            });

            defaultGuys[4].SoldierWargears.Add(new SoldierWargear()
            {
                Wargear = wargears.FirstOrDefault(o => o.WargearName == "Bow"),
                Soldier = defaultGuys[4]
            });

            defaultGuys[5].SoldierWargears.Add(new SoldierWargear()
            {
                Wargear = wargears.FirstOrDefault(o => o.WargearName == "Bow"),
                Soldier = defaultGuys[5]
            });

            context.Soldiers.AddRange(defaultGuys);

            newCompany.Size = 6;
            await context.SaveChangesAsync();

        }
    }
}
