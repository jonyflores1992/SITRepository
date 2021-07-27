using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SIT.Models;

namespace SIT.Controllers
{
    public class ComponentesController : BaseController
    {
        private readonly UserContext _context;

        public ComponentesController(UserContext context)
        {
            _context = context;
        }

        // GET: Componentes
        public async Task<IActionResult> Index()
        {
            var userContext = _context.Componente.Include(c => c.IdCategoriaNavigation).Include(c => c.IdProductoNavigation).Include(c => c.StatusNavigation);
            retornarMainMenu();retornarUserMenuItems();return View(await userContext.ToListAsync());
        }

        // GET: Componentes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var componente = await _context.Componente
                .Include(c => c.IdCategoriaNavigation)
                .Include(c => c.IdProductoNavigation)
                .Include(c => c.StatusNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (componente == null)
            {
                return NotFound();
            }

            retornarMainMenu();retornarUserMenuItems();return View(componente);
        }

        // GET: Componentes/Create
        public IActionResult Create()
        {
            ViewData["IdCategoria"] = new SelectList(_context.CategoriaProducto, "Id", "Categoria");
            ViewData["IdProducto"] = new SelectList(_context.Producto, "Id", "Producto1");
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status");
            retornarMainMenu();retornarUserMenuItems();return View();
        }

        // POST: Componentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Componente1,IdProducto,Kilogramos,Status,Descripcion,IdCategoria")] Componente componente)
        {
            if (ModelState.IsValid)
            {
                componente.Id = Guid.NewGuid();
                _context.Add(componente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategoria"] = new SelectList(_context.CategoriaProducto, "Id", "Categoria", componente.IdCategoria);
            ViewData["IdProducto"] = new SelectList(_context.Producto, "Id", "Producto1", componente.IdProducto);
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status", componente.Status);
            retornarMainMenu();retornarUserMenuItems();return View(componente);
        }

        // GET: Componentes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var componente = await _context.Componente.FindAsync(id);
            if (componente == null)
            {
                return NotFound();
            }
            ViewData["IdCategoria"] = new SelectList(_context.CategoriaProducto, "Id", "Categoria", componente.IdCategoria);
            ViewData["IdProducto"] = new SelectList(_context.Producto, "Id", "Producto1", componente.IdProducto);
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status", componente.Status);
            retornarMainMenu();retornarUserMenuItems();return View(componente);
        }

        // POST: Componentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Componente1,IdProducto,Kilogramos,Status,Descripcion,IdCategoria")] Componente componente)
        {
            if (id != componente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(componente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComponenteExists(componente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategoria"] = new SelectList(_context.CategoriaProducto, "Id", "Categoria", componente.IdCategoria);
            ViewData["IdProducto"] = new SelectList(_context.Producto, "Id", "Producto1", componente.IdProducto);
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status", componente.Status);
            retornarMainMenu();retornarUserMenuItems();return View(componente);
        }

        // GET: Componentes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var componente = await _context.Componente
                .Include(c => c.IdCategoriaNavigation)
                .Include(c => c.IdProductoNavigation)
                .Include(c => c.StatusNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (componente == null)
            {
                return NotFound();
            }

            retornarMainMenu();retornarUserMenuItems();return View(componente);
        }

        // POST: Componentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var componente = await _context.Componente.FindAsync(id);
            _context.Componente.Remove(componente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComponenteExists(Guid id)
        {
            return _context.Componente.Any(e => e.Id == id);
        }
    }
}
