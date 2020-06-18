using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BattleCompanies.Database;
using BattleCompanies.Models;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BattleCompanies.Controllers
{
    public class CampaignController : Controller
    {
        private readonly BattleCompanyContext _context;
        private List<Keyword> _keywords;

        public CampaignController(BattleCompanyContext context)
        {
            _context = context;
        }

 

        public async Task<IActionResult> Campaign(int CampaignID)
        {
            var companies = _context.Companies.Where(co => co.CompCampaign.CampaignID == CampaignID).Include(co => co.CompUser).Include(co => co.CompFaction);
            ViewBag.CampaignToPost = CampaignID;

            return View( await companies.ToListAsync());
        }

        public async Task<IActionResult> Create()
        {
            List<Faction> list = await _context.Factions.ToListAsync();
            ViewBag.facList = list;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Company company, int campID)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Companies.Add(company);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Campaign));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to make changes");
            }

            return RedirectToAction(nameof(Campaign), campID);
        }



        public async Task<Soldier> PromoteToHero(Soldier s)
        {
            Boolean IsHero = false;

            foreach(SoldierKeywords sk in s.SoldierKeywords)
            {
                if(sk.Keyword.KeywordText == "HERO")
                {
                    IsHero = true;
                    break;
                }
            }

            if (!IsHero)
            {
                var key = await _context.Keywords.FirstOrDefaultAsync(k => k.KeywordText == Keyword.HERO_KEYWORD);

                if (key != null)
                {
                    SoldierKeywords sk = new SoldierKeywords
                    {
                        Soldier = s,
                        Keyword = key
                    };

                    s.SoldierKeywords.Add(sk);
                    key.SoldierKeywords.Add(sk);

                    s.Fate = 1;

                    await _context.SaveChangesAsync();
                }

                
            }

            return s;
        }

        public async Task<Soldier> InitialPromotion(Soldier s)
        {
            s = await PromoteToHero(s);
            s.Might = 1;
            s.Will = 1;

            await _context.SaveChangesAsync();
            return s;
        }

        public async void PopulateKeys()
        {
            var keys = await _context.Keywords.ToListAsync();
            this._keywords = keys;
        }
    }
}
