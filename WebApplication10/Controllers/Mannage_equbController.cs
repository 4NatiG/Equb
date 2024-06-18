using WebApplication10.Data;
using WebApplication10.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebApplication10.Areas.Identity.Data;

namespace WebApplication10.Controllers
{
    public class Mannage_equbController : Controller
    {
        private readonly UserManager<Applicationuser> userManager;
        private readonly AppDbcontext _db;

        public Mannage_equbController(AppDbcontext db, UserManager<Applicationuser> userManager)
        {
            _db = db;
            this.userManager = userManager;
        }
        public IActionResult Mannage_e()
        {
            var equbs = _db.equb_detail.ToList();
            return View(equbs);
        }
        public IActionResult Created(equb_detail t)
        {
            var equbs = _db.equb_detail.ToList();
            TempData["acc"] = Convert.ToString(userManager.GetUserId(HttpContext.User));
            //ViewBag.temp = _db.Equb_detail;
            return RedirectToAction("participants",new { id=t.equb_id});
        }

        public IActionResult ViewDetail()
        {
            //var equbs = _db.Equb_detail.ToList();
            //ViewBag.temp = _db.Equb_detail;
            //TempData["cust_id"] = _db.Equb_detail;
            return View();
        }

        public IActionResult View_order()
        {
            //var equbs = _db.Equb_detail.ToList();
            //ViewBag.cust_id = _db.Equb_order;
            //TempData["cust_id"] = equb.Models.Equb_detail;
            return View();
        }
        public IActionResult Swap()
        {
            //var equbs = _db.Equb_detail.ToList();
            //ViewBag.temp = _db.Equb_detail;
            return View();
        }
        public IActionResult Join_equb()
        {
            //IEnumerable<equb_detail> objList = _db.equb_detail;
            //IEnumerable<Equb_order> objList2 = _db.equb_order;
            return View();
        }

        
        public int y;

        [HttpPost]
        public IActionResult Join_equb(Equb_order obj)
        {
            
            obj.user_id =  Convert.ToString(userManager.GetUserId(HttpContext.User));
            y= Convert.ToInt32(obj.equb_id);
            obj.order_no = 0;
            obj.status = "pending";
            _db.equb_order.Add(obj);
            _db.SaveChanges();
            return View(obj);
        }

        public IActionResult Participants()
        {
            
            return View();
            //IEnumerable<equb_detail> objList = _db.equb_detail;
            //IEnumerable<Equb_order> objList2 = _db.equb_order;
        }

        [HttpPost]
        public IActionResult Participants(equb_detail obj,int id)
        {
            //IEnumerable<equb_detail> equbs = _db.equb_detail;
            var equbs = _db.equb_detail.Find(id);
            TempData["x"] = equbs;

            return View(equbs);
            
            //IEnumerable<Equb_order> objList2 = _db.equb_order;
        }
    }
}
