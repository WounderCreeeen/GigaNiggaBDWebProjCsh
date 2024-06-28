using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Migrations
{
    public class _timestamp__InitialCreate : Controller
    {
        // GET: _timestamp__InitialCreate
        public ActionResult Index()
        {
            return View();
        }

        // GET: _timestamp__InitialCreate/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: _timestamp__InitialCreate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: _timestamp__InitialCreate/Create
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

        // GET: _timestamp__InitialCreate/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: _timestamp__InitialCreate/Edit/5
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

        // GET: _timestamp__InitialCreate/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: _timestamp__InitialCreate/Delete/5
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
