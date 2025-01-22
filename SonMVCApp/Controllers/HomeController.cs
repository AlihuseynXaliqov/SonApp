using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SonMVCApp.DAL.Context;

namespace SonMVCApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext dbContext;

        public HomeController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var agents= dbContext.Agents.Include(x=>x.Position).ToList();
            return View(agents);
        }

    }
}
