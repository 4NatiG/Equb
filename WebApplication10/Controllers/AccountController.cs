using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication10.Areas.Identity.Data;
using WebApplication10.Models;
using WebApplication10.Controllers;
namespace WebApplication10.Controllers
{ [Authorize]
    public class AccountController : Controller
    {

        private readonly Data.AppDbcontext _db;
        private readonly UserManager<Applicationuser> userManager;
        public AccountController(Data.AppDbcontext db,
            UserManager<Applicationuser> userManager)
        {
            _db = db;
            this.userManager = userManager;
        }
       public string en;
       
        public IActionResult Index()
        {
            IEnumerable<Account> objlist = _db.Account;
            return View(objlist);
            
        }
        
        public IActionResult Create()
        {
            
            en = userManager.GetUserId(HttpContext.User);
            TempData["user_id"] = en;
            Account account = new Account()
            {
                

            };

            return View(account);
        }
        [HttpPost]
        public IActionResult Create(Account obj)
        {

           
            _db.Account.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("index");
            
        }
        public IActionResult Get()
        {
            Account account = new Account() {
             
            };
            
            return View(account);
        }
        public IActionResult withdraw( String en)
        {
           
            return View();
        }
        public IActionResult update(int id,string val)
        {
            TempData["va"] = val;
            TempData["accid"] = id;

            ViewBag.e = TempData["va"];
            TempData["u"] = userManager.GetUserId(HttpContext.User);
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Account.Find(id);
           
    

            return View(obj);
        }
        [HttpPost]
        public IActionResult update(Account obj)
        {
            if (ModelState.IsValid)
            {
                _db.Account.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index","Transact", new {id=obj.account_id });
            }
            return View(obj);

        }
        public IActionResult transfer(int id, string val,string transferto, int acctran)
        {
            Account account = new Account()
            {

            };
            TempData["va"] = val;
            TempData["trans"] = transferto;
            TempData["user"]=userManager.GetUserId(HttpContext.User);
            TempData["acctra"] = acctran;
            TempData["id"] = id;
            ViewBag.s = TempData["trans"];
            ViewBag.e = TempData["va"];
            
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Account.Find(id);
           
           // var objt = _db.Account.Find(acctran);
         //   TempData["tra"] = objt;
            ViewBag.c = TempData["tra"];

            return View(obj); 
        }
        [HttpPost]
        public IActionResult transfer(Account obj, int id, string val, string transferto, int acctran)
        {

            if (ModelState.IsValid)
            {
                int id1 = id;
                int acctran1 = acctran;
                string val1 = val;
                string transferto1 = transferto;
                _db.Account.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("sendto", "Account", new { id = obj.account_id,acctran,val,transferto });
            }
            return View(obj);

        }

        public IActionResult sendto(int id, string val, string transferto, int acctran)
        {
            TempData["va"] = val;
            TempData["trans"] = transferto;
            TempData["user"] = userManager.GetUserId(HttpContext.User);
            TempData["acctra"] = acctran;
            ViewBag.s = TempData["trans"];
            ViewBag.e = TempData["va"];
            if (id == null || id == 0)
            {
                return NotFound();
            }
           
            var objt = _db.Account.Find(acctran);
            if (objt == null)
            {
                return NotFound();
            }

            return View(objt);
        }
        [HttpPost]
        public IActionResult sendto(Account objt)
        {
            if (ModelState.IsValid)
            {
                _db.Account.Update(objt);
                _db.SaveChanges();
                return RedirectToAction("transfer");
            }
            return View(objt);

        }


        /*
        public IActionResult withdraw(Account obj)
        {
            obj.balance = obj.balance - o;
            _db.Account.Update(obj);
            _db.SaveChanges();




            return View();
        }
      */
    }
}
