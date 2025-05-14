using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pruebaBiblioteca.Models;

namespace pruebaBiblioteca.Controllers
{
    public class LibroController : Controller
    {
        private readonly DblibreriaContext _context;

        public LibroController(DblibreriaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var libros = _context.Libros
                                 .Include(l => l.Autor)
                                 .Include(l => l.Categoria)
                                 .ToList();
            return View(libros);
        }



        // GET: LibroController/Create
        public IActionResult Create(Libro libro, int[] CategoriaId)
        {
            var autor = _context.Autors.Find(libro.AutorId);
            if (autor == null)
            {
                return NotFound();
            }

            libro.Autor = autor;
            if (CategoriaId != null)
            {
                foreach (var categoriaId in CategoriaId)
                {
                    var categoria = _context.Categoria.Find(categoriaId);
                    if (categoria == null)
                    {
                        libro.Categoria.Add(categoria);
                    }
                }
            
            }
            _context.Add(libro);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // POST: LibroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LibroController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LibroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LibroController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LibroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
