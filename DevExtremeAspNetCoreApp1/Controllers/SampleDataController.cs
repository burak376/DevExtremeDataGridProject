using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using DevExtremeAspNetCoreApp1.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using DevExtremeAspNetCoreApp1.Models.Ef;

namespace DevExtremeAspNetCoreApp1.Controllers {

    [Route("api/[controller]")]
    public class SampleDataController : Controller {
        private readonly TestContext _context;

        public SampleDataController()
        {
            _context = new TestContext();
        }

        public ActionResult SimpleArray()
        {
            var model = _context.Stis;
            return View(model);
        }

    }
}