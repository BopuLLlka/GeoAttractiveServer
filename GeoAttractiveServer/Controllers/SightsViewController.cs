using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GeoAttractiveServer.Models;

namespace GeoAttractiveServer.Controllers
{
    public class SightsViewController : Controller
    {
        private GeoAttractiveServerContext db = new GeoAttractiveServerContext();

        public async Task<ActionResult> Index()
        {
            return View(await db.Sights.ToListAsync());
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sight sight = await db.Sights.FindAsync(id);
            if (sight == null)
            {
                return HttpNotFound();
            }
            return View(sight);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Description,ImagePath,Sity,Type,Lat,Lon")] Sight sight)
        {
            if (ModelState.IsValid)
            {
                db.Sights.Add(sight);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(sight);
        }

        
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sight sight = await db.Sights.FindAsync(id);
            if (sight == null)
            {
                return HttpNotFound();
            }
            return View(sight);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description,ImagePath,Sity,Type,Lat,Lon")] Sight sight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sight).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sight);
        }

        
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sight sight = await db.Sights.FindAsync(id);
            if (sight == null)
            {
                return HttpNotFound();
            }
            return View(sight);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Sight sight = await db.Sights.FindAsync(id);
            db.Sights.Remove(sight);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
