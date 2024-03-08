using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD_MVC_socios_club.Models;
using Newtonsoft.Json.Linq;

namespace CRUD_MVC_socios_club.Controllers
{
    public class SociosDatumsController : Controller
    {
        private readonly socios_club_dbContext _context; 
        /*define una variable privada de solo lectura llamada _context que almacenará una instancia de socios_club_dbContext*/

        public SociosDatumsController(socios_club_dbContext context)
        {
            _context = context;
        }
        //El método Constructor es el que se llama cuando se crea una instancia de la clase SociosDatumsController.
        //Este constructor toma un parámetro de tipo socios_club_dbContext llamado context y lo asigna a la variable _context.

        // GET: SociosDatums
        public async Task<IActionResult> Index()
        {
              return _context.SociosData != null ? 
                          View(await _context.SociosData.ToListAsync()) :
                          Problem("Entity set 'socios_club_dbContext.SociosData'  is null.");
        }

        // GET: SociosDatums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SociosData == null)
            {
                return NotFound();
            }

            var sociosDatum = await _context.SociosData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sociosDatum == null)
            {
                return NotFound();
            }

            return View(sociosDatum);
        }

        // GET: SociosDatums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SociosDatums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Inscription,Type")] SociosDatum sociosDatum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sociosDatum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sociosDatum);
        }

        // GET: SociosDatums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SociosData == null)
            {
                return NotFound();
            }

            var sociosDatum = await _context.SociosData.FindAsync(id);
            if (sociosDatum == null)
            {
                return NotFound();
            }
            return View(sociosDatum);
        }

        // POST: SociosDatums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Inscription,Type")] SociosDatum sociosDatum)
        {
            if (id != sociosDatum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sociosDatum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SociosDatumExists(sociosDatum.Id))
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
            return View(sociosDatum);
        }

        // GET: SociosDatums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SociosData == null)
            {
                return NotFound();
            }

            var sociosDatum = await _context.SociosData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sociosDatum == null)
            {
                return NotFound();
            }

            return View(sociosDatum);
        }

        // POST: SociosDatums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SociosData == null)
            {
                return Problem("Entity set 'socios_club_dbContext.SociosData'  is null.");
            }
            var sociosDatum = await _context.SociosData.FindAsync(id);
            if (sociosDatum != null)
            {
                _context.SociosData.Remove(sociosDatum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SociosDatumExists(int id)
        {
          return (_context.SociosData?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
