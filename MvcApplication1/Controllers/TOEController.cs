using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class TOEController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        //
        // GET: /TOE/

        public ActionResult Index()
        {
            return View(db.TypesOfEquipments.ToList());
        }

        //
        // GET: /TOE/Details/5

        public ActionResult Details(string id = null)
        {
            TypesOfEquipment typesofequipment = db.TypesOfEquipments.Find(id);
            if (typesofequipment == null)
            {
                return HttpNotFound();
            }
            return View(typesofequipment);
        }

        //
        // GET: /TOE/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TOE/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TypesOfEquipment typesofequipment)
        {
            if (ModelState.IsValid)
            {
                if (db.TypesOfEquipments.Any(e=>e.Type==typesofequipment.Type))
                {
                    return View(typesofequipment);
                }
                db.TypesOfEquipments.Add(typesofequipment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typesofequipment);
        }

        //
        // GET: /TOE/Edit/5

        public ActionResult Edit(string id = null)
        {
            TypesOfEquipment typesofequipment = db.TypesOfEquipments.Find(id);
            if (typesofequipment == null)
            {
                return HttpNotFound();
            }
            return View(typesofequipment);
        }

        //
        // POST: /TOE/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TypesOfEquipment typesofequipment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typesofequipment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typesofequipment);
        }

        //
        // GET: /TOE/Delete/5

        public ActionResult Delete(string id = null)
        {
            TypesOfEquipment typesofequipment = db.TypesOfEquipments.Find(id);
            if (typesofequipment == null)
            {
                return HttpNotFound();
            }
            return View(typesofequipment);
        }

        //
        // POST: /TOE/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TypesOfEquipment typesofequipment = db.TypesOfEquipments.Find(id);
            db.TypesOfEquipments.Remove(typesofequipment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}