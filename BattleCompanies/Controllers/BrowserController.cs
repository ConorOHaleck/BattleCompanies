using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleCompanies.Database;
using BattleCompanies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BattleCompanies.Controllers
{
    public class BrowserController : Controller
    {
        private readonly BattleCompanyContext _context;

        public BrowserController(BattleCompanyContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Browser()
        {
            var campaigns = _context.Campaigns.Include(c => c.Companies).AsNoTracking();
            return View(await campaigns.ToListAsync());
        }

        public IActionResult NewCampaign()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewCampaign(
            [Bind("Title")] Campaign campaign)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Campaigns.Add(campaign);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Browser));
                }
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }

            return View(campaign);
        }

        public IActionResult EditCampaign()
        {


            return View();
        }
    }
}
