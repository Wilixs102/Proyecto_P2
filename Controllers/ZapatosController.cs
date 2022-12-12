using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto_P1.Data;
using Proyecto_P1.Models;

namespace Proyecto_P1.Controllers
{
    public class ZapatosController : Controller
    {
        private readonly Proyecto_P1Context _context;

        public ZapatosController(Proyecto_P1Context context)
        {
            _context = context;
        }

        // GET: Zapatos
        public async Task<IActionResult> Index()
        {
            var zapato = await _context.Zapatos.ToListAsync();
            return View(zapato);
        }

        // GET: Zapatos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Zapatos == null)
            {
                return NotFound();
            }

            var zapatos = await _context.Zapatos
                .FirstOrDefaultAsync(m => m.IdZapatos == id);
            if (zapatos == null)
            {
                return NotFound();
            }

            return View(zapatos);
        }

        // GET: Zapatos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zapatos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdZapatos,Marca,Modelo,Precio,Cantidad,Fecha")] Zapatos zapatos, IFormFile upload)
        {
            if (upload.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    upload.CopyTo(ms);
                    zapatos.Imagen = ms.ToArray();
                }
            }

            //if (ModelState.IsValid)
            {
                _context.Add(zapatos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //return View(zapatos);
        }

        // GET: Zapatos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Zapatos == null)
            {
                return NotFound();
            }

            var zapatos = await _context.Zapatos.FindAsync(id);
            if (zapatos == null)
            {
                return NotFound();
            }
            return View(zapatos);
        }

        // POST: Zapatos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdZapatos,Marca,Modelo,Precio,Cantidad,Fecha")] Zapatos zapatos)
        {
            if (id != zapatos.IdZapatos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zapatos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZapatosExists(zapatos.IdZapatos))
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
            return View(zapatos);
        }

        // GET: Zapatos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Zapatos == null)
            {
                return NotFound();
            }

            var zapatos = await _context.Zapatos
                .FirstOrDefaultAsync(m => m.IdZapatos == id);
            if (zapatos == null)
            {
                return NotFound();
            }

            return View(zapatos);
        }

        // POST: Zapatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Zapatos == null)
            {
                return Problem("Entity set 'Proyecto_P1Context.Zapatos'  is null.");
            }
            var zapatos = await _context.Zapatos.FindAsync(id);
            if (zapatos != null)
            {
                _context.Zapatos.Remove(zapatos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZapatosExists(int id)
        {
          return _context.Zapatos.Any(e => e.IdZapatos == id);
        }
    }

}
