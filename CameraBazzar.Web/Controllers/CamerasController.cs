using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CameraBazar.Models.Models;
using CameraBazzar.Data;
using CameraBazzar.Models.EntityModels;
using Microsoft.AspNet.Identity;

namespace CameraBazzar.Web.Controllers
{
    public class CamerasController : Controller
    {
        private CameraBazzarContext db = new CameraBazzarContext();

        // GET: Cameras
        public ActionResult Index()
        {
            return View(db.Cameras.ToList());
        }

        // GET: Cameras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camera camera = db.Cameras.Find(id);
            if (camera == null)
            {
                return HttpNotFound();
            }
            return View(camera);
        }

        // GET: Cameras/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cameras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Make,Model,Price,Quantity,MinShutterSpeed,MaxShutterSpeed,MinIso,MaxIso,IsFullFrame,VideoResolution,Spot,CenterWeighted,Evaluative,Description,ImageUrl")] Camera camera)
        {
            string userId = User.Identity.GetUserId();
            camera.ApplicationUser = db.Users.Find(userId);

            if (ModelState.IsValid)
            {
                db.Cameras.Add(camera);
                db.SaveChanges();
                return RedirectToAction("MyProfile", "Cameras");
            }

            return View(camera);
        }

        // GET: Cameras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camera camera = db.Cameras.Find(id);
            if (camera == null)
            {
                return HttpNotFound();
            }
            return View(camera);
        }

        // POST: Cameras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Make,Model,Price,Quantity,MinShutterSpeed,MaxShutterSpeed,MinIso,MaxIso,IsFullFrame,VideoResolution,Spot,CenterWeighted,Evaluative,Description,ImageUrl")] Camera camera)
        {
            if (ModelState.IsValid)
            {
                db.Entry(camera).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(camera);
        }

        // GET: Cameras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camera camera = db.Cameras.Find(id);
            if (camera == null)
            {
                return HttpNotFound();
            }
            return View(camera);
        }

        // POST: Cameras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Camera camera = db.Cameras.Find(id);
            db.Cameras.Remove(camera);
            db.SaveChanges();
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

        [Authorize]

        public ActionResult MyProfile(string id)
        {
            return View(db.Users.FirstOrDefault(u => u.Id.Equals(id)));
        }
    }
}
