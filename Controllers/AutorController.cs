using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pruebaBiblioteca.Models;

namespace pruebaBiblioteca.Controllers
{
    public class AutorController : Controller
    {
        private readonly DblibreriaContext _context;
        
        public AutorController(DblibreriaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var autores = _context.Autors.Include(a => a.Libros).ToList();
            return View(autores);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(Autor autor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autor);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
                   
            }
            return View(autor);
        }
            
    }
}
