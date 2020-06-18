using BattleCompanies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleCompanies.Database
{
    public static class DBInitializer
    {

        //Initialize seeds the database, if it doesn't have the correct columns already.
        public static void Initialize(BattleCompanyContext context)
        {
            context.Database.EnsureCreated();


            //Declared outside if statements so they can be used to join later tables
            Keyword[] keywords;
            Wargear[] wargears;
            Faction[] factions;


            //This table of keywords can be used as-is even if the keyword table has already been created.
            //There should be no difference whatsoever between this array of keywords
            keywords = new Keyword[]
            {
                new Keyword(Keyword.HERO_KEYWORD),
                new Keyword(Keyword.INF_KEYWORD),
                new Keyword(Keyword.CAV_KEYWORD),
                new Keyword(Keyword.BEAST_KEYWORD),
                new Keyword(Keyword.MAN_KEYWORD),
                new Keyword(Keyword.HOBBIT_KEYWORD),
                new Keyword(Keyword.ELF_KEYWORD),
                new Keyword(Keyword.DWARF_KEYWORD),
                new Keyword(Keyword.ORC_KEYWORD),
                new Keyword(Keyword.URUK_KEYWORD)
            };

            if (!context.Keywords.Any())
            {
                foreach (Keyword k in keywords)
                {
                    context.Keywords.Add(k);
                }

                context.SaveChanges();
            }


            wargears = new Wargear[]
            {
                new Wargear("Sword", false, false),//0
                new Wargear("Axe", false, false), //1
                new Wargear("Club", false, false), //2
                new Wargear("Staff", false, false), //3
                new Wargear("Flail", false, false), //4
                new Wargear("Spear", false, false), //5
                new Wargear("Pike", false, false), //6
                new Wargear("Lance", false, false), //7
                new Wargear("Shield", false, false), //8
                new Wargear("Armor", false, false), //9
                new Wargear("Heavy Armor", false, false), //10
                new Wargear("Dwarf Armor", false, false), //11
                new Wargear("Elven Cloak", false, false), //12
                new Wargear("Banner", false, false), //13
                new Wargear("War Horn", false, false), //14
                new Wargear("Twohanded Sword", true, false), //15
                new Wargear("Twohanded Axe", true, false), //16 
                new Wargear("Twohanded Club", true, false), //17
                new Wargear("Twohanded Staff", true, false), //18
                new Wargear("Twohanded Flail", true, false), //19
                new Wargear("Bow", false, true), //20
                new Wargear("Crossbow", false, true), //21
                new Wargear("Longbow", false, true), //22
                new Wargear("Dwarf Bow", false, true), //23
                new Wargear("Elf Bow", false, true), //24
                new Wargear("Orc Bow", false, true), //25
                new Wargear("Horse", false, false), //26
                new Wargear("Armored Horse", false, false), //27
                new Wargear("Warg", false, false),//28
                new Wargear("Elven Sword", false, false) //29
            };

            if (!context.Wargears.Any())
            {
                foreach (Wargear w in wargears)
                {
                    context.Wargears.Add(w);
                }

                context.SaveChanges();
            }


            //Additional Factions should have their own entries in this array, as well as their own complete set of wargears
            if (!context.Factions.Any())
            {
                factions = new Faction[]
                {
                    new Faction{
                        FactionName = "Minas Tirith",
                        FactionWargears = new List<FactionWargear>()
                    },
                    new Faction{
                        FactionName = "Mordor",
                        FactionWargears = new List<FactionWargear>() 
                    }

                };

                List<Wargear> gondorArmory = new List<Wargear>()
                {
                    wargears[0], wargears[5], wargears[7], wargears[8], wargears[9], wargears[10], wargears[13], wargears[14], wargears[20], wargears[22], wargears[26]
                };

                List<Wargear> OrcArmory = new List<Wargear>()
                {
                    wargears[0], wargears[1], wargears[2], wargears[5], wargears[8], wargears[9], wargears[10], wargears[13], wargears[14], wargears[17], wargears[25]
                };

                foreach( Wargear w in gondorArmory)
                {
                    var connection = new FactionWargear()
                    {
                        Faction = factions[0],
                        Wargear = w
                    };

                    factions[0].FactionWargears.Add(connection);
                    w.FactionWargears.Add(connection);
                }

                foreach( Wargear w in OrcArmory)
                {
                    var connection = new FactionWargear()
                    {
                        Faction = factions[1],
                        Wargear = w
                    };

                    factions[1].FactionWargears.Add(connection);
                    w.FactionWargears.Add(connection);
                }


                foreach(Faction f in factions)
                {
                    context.Factions.Add(f);
                }

                context.SaveChanges();
            }
        }
    }
}
