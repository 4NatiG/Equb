using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication10.Areas.Identity.Data;
using WebApplication10.Models;
namespace WebApplication10.Controllers
{
    public class TransactController : Controller
    {
        private readonly Data.AppDbcontext _db;
        private readonly UserManager<Applicationuser> userManager;
        public TransactController(Data.AppDbcontext db, UserManager<Applicationuser> userManager)
        {
            _db = db;
            this.userManager = userManager;
        }
        public IActionResult Index(int id)
        {
            IEnumerable<Transact> objlist = _db.Transact;
            TempData["num"] =userManager.GetUserId(HttpContext.User);
            return View(objlist);
        }
        public IActionResult Deposit( )
        {
            Transact objlist = new Transact() ;
            List<SelectListItem> items = new List<SelectListItem>();
            SelectListItem item1 = new SelectListItem() { Text = "Deposit",Value="1",Selected=true};
            SelectListItem item2 = new SelectListItem() { Text = "Withdraw", Value = "2", Selected = false };
            items.Add(item1);
            items.Add(item2);

            ViewBag.trans_type = items;



            TempData["userid"] = userManager.GetUserId(HttpContext.User);
            
            return View(objlist);
        }
        [HttpPost]
        public IActionResult Deposit(Transact obj)
        {
            int b =Convert.ToInt32(Request.Form["amount"]);
            TempData["acc"] =b ;
            string y= userManager.GetUserId(HttpContext.User);
            if (y == obj.trans_to) {


                _db.Transact.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("update", "Account", new { id = obj.account_id, val = obj.trans_type, transferto = obj.trans_to });
            }

            _db.Transact.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("transfer", "Account", new { id = obj.account_id, val = obj.trans_type, transferto = obj.trans_to, acctran = obj.ac_id });
            
            
          
            
        }
        public IActionResult transfer()
        {
            
            return View();
        }
    }
}
