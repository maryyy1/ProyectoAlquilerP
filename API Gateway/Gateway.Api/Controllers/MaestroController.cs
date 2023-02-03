using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Api.Controllers
{
    public class MaestroController : Controller
    {
        // GET: MaestroController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MaestroController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MaestroController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MaestroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MaestroController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MaestroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MaestroController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MaestroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
