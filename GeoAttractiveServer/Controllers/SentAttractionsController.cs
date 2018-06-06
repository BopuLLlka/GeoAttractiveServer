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
    public class SentAttractionsController : Controller
    {
        private GeoAttractiveServerContext db = new GeoAttractiveServerContext();

        // GET: SentAttractions
        public async Task<ActionResult> Index()
        {
            return View(await db.SentAttractions.ToListAsync());
        }

        // GET: SentAttractions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SentAttractions sentAttractions = await db.SentAttractions.FindAsync(id);
            if (sentAttractions == null)
            {
                return HttpNotFound();
            }
            return View(sentAttractions);
        }

        // GET: SentAttractions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SentAttractions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Description,ImagePath,Sity,Type,Lat,Lon,Status")] SentAttractions sentAttractions)
        {
            if (ModelState.IsValid)
            {
                db.SentAttractions.Add(sentAttractions);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(sentAttractions);
        }

        // GET: SentAttractions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SentAttractions sentAttractions = await db.SentAttractions.FindAsync(id);
            if (sentAttractions == null)
            {
                return HttpNotFound();
            }
            return View(sentAttractions);
        }

        // POST: SentAttractions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description,ImagePath,Sity,Type,Lat,Lon,Status")] SentAttractions sentAttractions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sentAttractions).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sentAttractions);
        }

        // GET: SentAttractions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SentAttractions sentAttractions = await db.SentAttractions.FindAsync(id);
            if (sentAttractions == null)
            {
                return HttpNotFound();
            }
            return View(sentAttractions);
        }

        // POST: SentAttractions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SentAttractions sentAttractions = await db.SentAttractions.FindAsync(id);
            db.SentAttractions.Remove(sentAttractions);
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
