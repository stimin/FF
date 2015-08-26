using FF.Models;
using System.Web.Mvc;

namespace FF.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // POST: Home
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Form form)
        {
            // Output the error messages if input invalid
            var wall = new Wall(form.WallSize);

            if (!wall.Valid)
            {
                ModelState.AddModelError("WallSize", "Value must be two numbers separated by space (i.e. '5 8')");
            }

            var robot = new Robot(wall, form.RobotStart);

            if (!robot.Valid)
            {
                ModelState.AddModelError("RobotStart", "Value must be two numbers within set wall size and either Left, Right, Up or Down, separated by space (i.e. '2 3 Up')");
            }
        
            if (ModelState.IsValid)
            {
                // Everything valid so run instructions
                form.Output = robot.Run(form.Instructions);
            }
            return View(form);
        }
    }
}