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
    //BrowserController is for the various menus outside the main campaign page
    public class BrowserController : Controller
    {
        private readonly BattleCompanyContext _context;

        //Dependency injection applies the Database Context into the controller
        public BrowserController(BattleCompanyContext context)
        {
            _context = context;
        }

        //Allows user to browse through games, shouldn't be able to edit on this screen
        public async Task<IActionResult> Browser()
        {
            var campaigns = _context.Campaigns.Include(c => c.Companies).AsNoTracking();
            return View(await campaigns.ToListAsync());
        }

        //This pair of functions, NewCampaign and overloaded NewCampaign (which is the Post version), allow a user to create a campaign from scratch
        //TODO: Enable automatic registering of the user who created the campaign as that campaign's administrator, and automatically set them up with a Company
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

        //This option should only appear for a user that is an administrator, and brings them to a special Campaign screen
        //TODO: Unimplemented Method
        public IActionResult EditCampaign()
        {
            return View();
        }
    }
}
