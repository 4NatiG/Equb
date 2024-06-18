using WebApplication10.Data;
using WebApplication10.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebApplication10.Areas.Identity.Data;
using WebApplication10.Areas.Identity.Pages.Account;
namespace WebApplication10.Controllers
{
    public class CreateEqubController : Controller
        
    {
        private readonly UserManager<Applicationuser> userManager;
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly AppDbcontext _db;

        public CreateEqubController(AppDbcontext db, UserManager<Applicationuser> userManager, RoleManager<IdentityRole> _rolemanager)
        {
            _db = db;
            this.userManager = userManager;
            this._rolemanager = _rolemanager;
        }
        
        public IActionResult Index()
        {
            IEnumerable<equb_detail> objList = _db.equb_detail;
            return View(objList);
        }
        
        public IActionResult Create()
        {
             string v=userManager.GetUserId(HttpContext.User);
            TempData["acc"] = v;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(equb_detail obj)
        {

             

            obj.status = "open";

                if (obj.cycle.ToString()=="monthly")
                {
                    obj.end_date = obj.start_date.AddMonths(obj.duration);
                }
                else if(obj.cycle.ToString() == "daily")
                {
                    obj.end_date = obj.start_date.AddDays(obj.duration);
                }
                else if (obj.cycle.ToString() == "weekly")
                {
                    var weeks = obj.duration * 7;
                    obj.end_date = obj.start_date.AddDays(weeks);
                }
                _db.equb_detail.Add(obj);
                _db.SaveChanges();
                return View(obj);
            
            
        }

        public IActionResult Reserve()
        {
            return View();
        }
    }
}
