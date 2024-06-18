using WebApplication10.Data;
using WebApplication10.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication10.Controllers
{
    public class FundsController : Controller
    {
        private readonly AppDbcontext _db;
        public FundsController(AppDbcontext db)
        {
            _db = db;
        }
        public IActionResult Fund_history()
        {
            return View();
        }
        public IActionResult Transfer()
        {
            return View();
        }
    }
}
