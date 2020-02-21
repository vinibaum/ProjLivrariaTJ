using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LivrariaTJ.DAL;
using LivrariaTJ.Models;

namespace LivrariaTJ.Controllers
{
    public class LivrosController : Controller
    {
        private LivrariaContext db = new LivrariaContext();

        // GET: Livros
        public ActionResult Index()
        {
            return View(db.Livros.ToList());
        }

        // GET: Livros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livro livro = db.Livros.Find(id);
            if (livro == null)
            {
                return HttpNotFound();
            }
            return View(livro);
        }

        // GET: Livros/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Livros/Galeria
        public ActionResult Galeria()
        {
            return View(db.Livros.ToList());
        }

        // GET: Livros/Pesuisar
        public ActionResult Pesquisar(string ordenacao, string NomeParaPesquisa)
        {

            var livros = from s in db.Livros
                           select s;
            if (!String.IsNullOrEmpty(NomeParaPesquisa))
            {
                livros = livros.Where(s => s.Titulo.Contains(NomeParaPesquisa)
                                       || s.Autor.Contains(NomeParaPesquisa));
            }
            switch (ordenacao)
            {
                case "titulo":
                    livros = livros.OrderByDescending(s => s.Titulo);
                    break;
                case "autor":
                    livros = livros.OrderBy(s => s.Autor);
                    break;
            }
            return View(livros.ToList());
        }

        // POST: Livros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LivroID,Titulo,Genero,DataPublicacao,NumeroPaginas,Autor,Editora,Descricao,Sinopse,ImagemCapa,LinksParaCompra")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                db.Livros.Add(livro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(livro);
        }

        // GET: Livros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livro livro = db.Livros.Find(id);
            if (livro == null)
            {
                return HttpNotFound();
            }
            return View(livro);
        }

        // POST: Livros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LivroID,Titulo,Genero,DataPublicacao,NumeroPaginas,Autor,Editora,Descricao,Sinopse,ImagemCapa,LinksParaCompra")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(livro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(livro);
        }

        // GET: Livros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livro livro = db.Livros.Find(id);
            if (livro == null)
            {
                return HttpNotFound();
            }
            return View(livro);
        }

        // POST: Livros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Livro livro = db.Livros.Find(id);
            db.Livros.Remove(livro);
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
    }
}
