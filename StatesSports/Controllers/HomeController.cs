using StatesSports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StatesSports.Controllers
{
    public class HomeController : Controller
    {
        SportsEntities db = new SportsEntities();
        public ActionResult Index()

        {
            /** Creates list for the "Select a State" drop-down **/

            List<State> StateList = db.States.ToList();
            ViewBag.StateList = new SelectList(StateList, "StateId", "StateName");
            return View();
        }

        /**
            Function to be used in the Ajax request.
            Passes StateId, runs a LINQ query on it, 
            appends the result to TeamList,
            and returns the data as Json.
        **/
        
        public JsonResult GetTeamList(int StateId)
        { 
            db.Configuration.ProxyCreationEnabled = false;
            List<Team> TeamList = db.Teams.Where(x => x.StateId == StateId).ToList();
            return Json(TeamList, JsonRequestBehavior.AllowGet);

        }
    }
}