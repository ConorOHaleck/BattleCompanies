using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleCompanies.Database;
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

        public IActionResult EditCampaign()
        {
            return View();
        }
    }
}
