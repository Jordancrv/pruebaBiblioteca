using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pruebaBiblioteca.Models;

namespace pruebaBiblioteca.Controllers
{
    public class EditorialController : Controller
    {
        private readonly DblibreriaContext _context;

        public EditorialController(DblibreriaContext context)
        {
            _context = context;
        }


        // GET: EditorialController/Details/5
        public IActionResult Details(int id)
        {
            var editoriales = _context.Editorials
                                      .Include(c => c.Libro)
                                      .ToList();
            return View(editoriales);
        }

        // GET: EditorialController/Create
        public IActionResult Create()
        {
            ViewBag.Libros = new SelectList(_context.Libros, "LibroId", "Titulo");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Editorial editorial)
        {
            _context.Add(editorial);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
