using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Api.Controllers
{
    public class RecargaController : Controller
    {
        // GET: RecargaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RecargaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RecargaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecargaController/Create
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

        // GET: RecargaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RecargaController/Edit/5
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

        // GET: RecargaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RecargaController/Delete/5
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
