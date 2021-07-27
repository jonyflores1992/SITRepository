using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIT.Models;

namespace SIT.Controllers
{
    public class CategoriaProductoesController : BaseController
    {
        private readonly UserContext _context;

        public CategoriaProductoesController(UserContext context)
        {
            _context = context;
        }

        // GET: CategoriaProductoes
        public async Task<IActionResult> Index()
        {
            retornarMainMenu();retornarUserMenuItems();return View(await _context.CategoriaProducto.ToListAsync());
        }

        // GET: CategoriaProductoes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaProducto = await _context.CategoriaProducto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoriaProducto == null)
            {
                return NotFound();
            }

            retornarMainMenu();retornarUserMenuItems();return View(categoriaProducto);
        }

        // GET: CategoriaProductoes/Create
        public IActionResult Create()
        {
            retornarMainMenu();retornarUserMenuItems();return View();
        }

        // POST: CategoriaProductoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Categoria,CreatedAt,UpdateAt,Delete")] CategoriaProducto categoriaProducto)
        {
            if (ModelState.IsValid)
            {
                categoriaProducto.Id = Guid.NewGuid();
                _context.Add(categoriaProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            retornarMainMenu();retornarUserMenuItems();return View(categoriaProducto);
        }

        // GET: CategoriaProductoes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaProducto = await _context.CategoriaProducto.FindAsync(id);
            if (categoriaProducto == null)
            {
                return NotFound();
            }
            retornarMainMenu();retornarUserMenuItems();return View(categoriaProducto);
        }

        // POST: CategoriaProductoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Categoria,CreatedAt,UpdateAt,Delete")] CategoriaProducto categoriaProducto)
        {
            if (id != categoriaProducto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaProductoExists(categoriaProducto.Id))
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
            retornarMainMenu();retornarUserMenuItems();return View(categoriaProducto);
        }

        // GET: CategoriaProductoes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaProducto = await _context.CategoriaProducto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoriaProducto == null)
            {
                return NotFound();
            }

            retornarMainMenu();retornarUserMenuItems();return View(categoriaProducto);
        }

        // POST: CategoriaProductoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var categoriaProducto = await _context.CategoriaProducto.FindAsync(id);
            _context.CategoriaProducto.Remove(categoriaProducto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaProductoExists(Guid id)
        {
            return _context.CategoriaProducto.Any(e => e.Id == id);
        }
    }
}
