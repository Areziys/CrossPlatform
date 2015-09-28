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
    public class DefaultController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        //
        // GET: /Default/

        public ActionResult Index(Equipment equipment=null)
        {
            var equipments = db.Equipments.Include(e => e.TypesOfEquipment);
            if (equipment == null)                
                return View(equipments.ToList());
            var rez = new List<Equipment>();
            if (!string.IsNullOrEmpty(equipment.Name))
                rez.AddRange(equipments.Where(e => e.Name == equipment.Name));
            if (!string.IsNullOrEmpty(equipment.TerialNumber))
                rez.AddRange(equipments.Where(e => e.TerialNumber == equipment.TerialNumber));
            if (!string.IsNullOrEmpty(equipment.Type))
                rez.AddRange(equipments.Where(e => e.Type == equipment.Type));
            return View(rez);
        }

        //
        // GET: /Default/Details/5

        public ActionResult Details(int id = 0)
        {
            Equipment equipment = db.Equipments.Find(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return View(equipment);
        }

        //
        // GET: /Default/Create

        public ActionResult Create()
        {
            ViewBag.Type = new SelectList(db.TypesOfEquipments, "Type", "Type");
            return View();
        }

        //
        // POST: /Default/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                equipment.Id = db.Equipments.Max(e => e.Id) + 1;
                db.Equipments.Add(equipment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Type = new SelectList(db.TypesOfEquipments, "Type", "Type", equipment.Type);
            return View(equipment);
        }

        //
        // GET: /Default/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Equipment equipment = db.Equipments.Find(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            ViewBag.Type = new SelectList(db.TypesOfEquipments, "Type", "Type", equipment.Type);
            return View(equipment);
        }

        //
        // POST: /Default/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Type = new SelectList(db.TypesOfEquipments, "Type", "Type", equipment.Type);
            return View(equipment);
        }

        //
        // GET: /Default/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Equipment equipment = db.Equipments.Find(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return View(equipment);
        }

        //
        // POST: /Default/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Equipment equipment = db.Equipments.Find(id);
            db.Equipments.Remove(equipment);
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