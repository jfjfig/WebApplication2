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
    public class ViaturasController : Controller
    {
        private MultasDb db = new MultasDb();

        // GET: Viaturas
        public async Task<ActionResult> Index()
        {
            return View(await db.Viaturas.ToListAsync());
        }

        // GET: Viaturas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viaturas viaturas = await db.Viaturas.FindAsync(id);
            if (viaturas == null)
            {
                return HttpNotFound();
            }
            return View(viaturas);
        }

        // GET: Viaturas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Viaturas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Matricula,Marca,Modelo,Cor,NomeDono,MoradaDono,CodPostalDono")] Viaturas viaturas)
        {
            if (ModelState.IsValid)
            {
                db.Viaturas.Add(viaturas);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(viaturas);
        }

        // GET: Viaturas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viaturas viaturas = await db.Viaturas.FindAsync(id);
            if (viaturas == null)
            {
                return HttpNotFound();
            }
            return View(viaturas);
        }

        // POST: Viaturas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Matricula,Marca,Modelo,Cor,NomeDono,MoradaDono,CodPostalDono")] Viaturas viaturas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viaturas).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(viaturas);
        }

        // GET: Viaturas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viaturas viaturas = await db.Viaturas.FindAsync(id);
            if (viaturas == null)
            {
                return HttpNotFound();
            }
            return View(viaturas);
        }

        // POST: Viaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Viaturas viaturas = await db.Viaturas.FindAsync(id);
            db.Viaturas.Remove(viaturas);
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
