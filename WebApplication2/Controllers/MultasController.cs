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
    public class MultasController : Controller
    {
        private MultasDb db = new MultasDb();

        // GET: Multas
        public async Task<ActionResult> Index()
        {
            var multas = db.Multas.Include(m => m.Agente).Include(m => m.Condutor).Include(m => m.Viatura);
            return View(await multas.ToListAsync());
        }

        // GET: Multas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Multas multas = await db.Multas.FindAsync(id);
            if (multas == null)
            {
                return HttpNotFound();
            }
            return View(multas);
        }

        // GET: Multas/Create
        public ActionResult Create()
        {
            ViewBag.AgenteFK = new SelectList(db.Agentes, "ID", "Nome");
            ViewBag.CondutorFK = new SelectList(db.Condutores, "ID", "Nome");
            ViewBag.ViaturaFK = new SelectList(db.Viaturas, "ID", "Matricula");
            return View();
        }

        // POST: Multas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,LocalDaMulta,DataDaMulta,Infracao,ValorMulta,AgenteFK,ViaturaFK,CondutorFK")] Multas multas)
        {
            if (ModelState.IsValid)
            {
                db.Multas.Add(multas);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AgenteFK = new SelectList(db.Agentes, "ID", "Nome", multas.AgenteFK);
            ViewBag.CondutorFK = new SelectList(db.Condutores, "ID", "Nome", multas.CondutorFK);
            ViewBag.ViaturaFK = new SelectList(db.Viaturas, "ID", "Matricula", multas.ViaturaFK);
            return View(multas);
        }

        // GET: Multas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Multas multas = await db.Multas.FindAsync(id);
            if (multas == null)
            {
                return HttpNotFound();
            }
            ViewBag.AgenteFK = new SelectList(db.Agentes, "ID", "Nome", multas.AgenteFK);
            ViewBag.CondutorFK = new SelectList(db.Condutores, "ID", "Nome", multas.CondutorFK);
            ViewBag.ViaturaFK = new SelectList(db.Viaturas, "ID", "Matricula", multas.ViaturaFK);
            return View(multas);
        }

        // POST: Multas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,LocalDaMulta,DataDaMulta,Infracao,ValorMulta,AgenteFK,ViaturaFK,CondutorFK")] Multas multas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(multas).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AgenteFK = new SelectList(db.Agentes, "ID", "Nome", multas.AgenteFK);
            ViewBag.CondutorFK = new SelectList(db.Condutores, "ID", "Nome", multas.CondutorFK);
            ViewBag.ViaturaFK = new SelectList(db.Viaturas, "ID", "Matricula", multas.ViaturaFK);
            return View(multas);
        }

        // GET: Multas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Multas multas = await db.Multas.FindAsync(id);
            if (multas == null)
            {
                return HttpNotFound();
            }
            return View(multas);
        }

        // POST: Multas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Multas multas = await db.Multas.FindAsync(id);
            db.Multas.Remove(multas);
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
