using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pruebaBiblioteca.Models;

namespace pruebaBiblioteca.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly DblibreriaContext _context;

        public CategoriaController(DblibreriaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categorias = _context.Categoria
                                     .Include(c => c.Libros)
                                     .ToList();
            return View(categorias);
        }

        public IActionResult create()
        {
            return View();
        }

        // POST: CategoriaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Categorium categoria)
        {
                _context.Add(categoria);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            
        }
        
    }
}
