using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VideoStore.Controllers
{
    public class ArchiveController : Controller
    {
        // GET: Archive
        public ActionResult Index()
        {
            return View();
        }
        [Route("archive/{year:regex(\\d{4})}/{month:regex(\\d{1,2})}/{day:regex(\\d{1,2})}")]
        public ActionResult ShowArchive(int year, int month, int day)
        {
            return Content(year + "/" + month + "/" + day);
        }
    }
}