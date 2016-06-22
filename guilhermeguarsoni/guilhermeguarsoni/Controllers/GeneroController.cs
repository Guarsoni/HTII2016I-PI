using System.Linq;
using System.Web.Mvc;
using guilhermeguarsoni.Models;
using System.Net;
using System.Data.Entity;

namespace guilhermeguarsoni.Controllers
{
    public class GeneroController : Controller
    {
        private AppContext db = new AppContext();
        
        // GET: Genero
        public ActionResult Index()
        {
            return View(db.Generos.ToList());
        }

        //Get: Genero/Insert
        public ActionResult Insert()
        {
            return View();
        }
        // POST: Genero/Insert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insert([Bind(Include = "Id,Descrição")] Genero genero)
        {
            if(ModelState.IsValid)
            {
                db.Generos.Add(genero);
                db.SaveChanges();
                return RedirectToAction("Index"); 
            }
            return View(genero);
        }
        // GET: Generos/Update/<id>
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genero genero = db.Generos.Find(id);
            if (genero == null)
            {
                return HttpNotFound();
            }
            return View(genero);
        }
        //POST: Genero/Update/<id>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include = "Id,Descrição")] Genero genero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
                return View(genero);
        }
        //GET: Genero/Delete/<id>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); 
            }
            Genero genero = db.Generos.Find(id);
            if (genero == null)
             {
                return HttpNotFound();
            }
            return View(genero);
        }
        //POST: Generos/Delete/<id>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Genero genero = db.Generos.Find(id);
            db.Generos.Remove(genero);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}