using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CondutoresController : Controller
    {
        private MultasDb db = new MultasDb();

        // GET: Condutores
        public async Task<ActionResult> Index()
        {
            return View(await db.Condutores.ToListAsync());
        }

        // GET: Condutores/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condutores condutores = await db.Condutores.FindAsync(id);
            if (condutores == null)
            {
                return HttpNotFound();
            }
            return View(condutores);
        }

        // GET: Condutores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Condutores/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Nome,BI,Telemovel,DataNascimento,NumCartaConducao,LocalEmissao,DataValidadeCarta")] Condutores condutores)
        {
            if (ModelState.IsValid)
            {
                db.Condutores.Add(condutores);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(condutores);
        }

        // GET: Condutores/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condutores condutores = await db.Condutores.FindAsync(id);
            if (condutores == null)
            {
                return HttpNotFound();
            }
            return View(condutores);
        }

        // POST: Condutores/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Nome,BI,Telemovel,DataNascimento,NumCartaConducao,LocalEmissao,DataValidadeCarta")] Condutores condutores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(condutores).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(condutores);
        }

        // GET: Condutores/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condutores condutores = await db.Condutores.FindAsync(id);
            if (condutores == null)
            {
                return HttpNotFound();
            }
            return View(condutores);
        }

        // POST: Condutores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Condutores condutores = await db.Condutores.FindAsync(id);
            db.Condutores.Remove(condutores);
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
