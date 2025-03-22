using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProgettosettimanaleS6L5.Data;
using ProgettosettimanaleS6L5.Models;

namespace ProgettosettimanaleS6L5.Controllers
{
    public class PrenotazioniController : Controller
    {
        private readonly AppDbContext _context;

        public PrenotazioniController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Prenotazioni
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Prenotazioni.Include(p => p.Camera).Include(p => p.Cliente);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Prenotazioni/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prenotazione = await _context.Prenotazioni
                .Include(p => p.Camera)
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(m => m.PrenotazioneId == id);
            if (prenotazione == null)
            {
                return NotFound();
            }

            return View(prenotazione);
        }

        // GET: Prenotazioni/Create
        public IActionResult Create()
        {
            ViewData["Clienti"] = _context.Clienti.ToList();
            ViewData["CameraId"] = new SelectList(_context.Camere, "CameraId", "CameraId");
            ViewData["ClienteId"] = new SelectList(_context.Clienti, "ClienteId", "ClienteId");
            return View();
        }

        // POST: Prenotazioni/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrenotazioneId,ClienteId,CameraId,DataInizio,DataFine,Stato")] Prenotazione prenotazione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prenotazione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Clienti"] = _context.Clienti.ToList();
            ViewData["CameraId"] = new SelectList(_context.Camere, "CameraId", "CameraId", prenotazione.CameraId);
            ViewData["ClienteId"] = new SelectList(_context.Clienti, "ClienteId", "ClienteId", prenotazione.ClienteId);
            return View(prenotazione);
        }

        // GET: Prenotazioni/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prenotazione = await _context.Prenotazioni.FindAsync(id);
            if (prenotazione == null)
            {
                return NotFound();
            }
            ViewData["CameraId"] = new SelectList(_context.Camere, "CameraId", "CameraId", prenotazione.CameraId);
            ViewData["ClienteId"] = new SelectList(_context.Clienti, "ClienteId", "ClienteId", prenotazione.ClienteId);
            return View(prenotazione);
        }

        // POST: Prenotazioni/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrenotazioneId,ClienteId,CameraId,DataInizio,DataFine,Stato")] Prenotazione prenotazione)
        {
            if (id != prenotazione.PrenotazioneId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prenotazione);
                    await _context.SaveChangesAsync();

                    if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    {
                        return Json(new { success = true, message = "Prenotazione aggiornata con successo!" });
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrenotazioneExists(prenotazione.PrenotazioneId))
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

            ViewData["CameraId"] = new SelectList(_context.Camere, "CameraId", "CameraId", prenotazione.CameraId);
            ViewData["ClienteId"] = new SelectList(_context.Clienti, "ClienteId", "ClienteId", prenotazione.ClienteId);
            return View(prenotazione);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prenotazione = await _context.Prenotazioni
                .Include(p => p.Camera)
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(m => m.PrenotazioneId == id);
            if (prenotazione == null)
            {
                return NotFound();
            }

            return View(prenotazione);
        }

        // POST: Prenotazioni/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prenotazione = await _context.Prenotazioni.FindAsync(id);
            if (prenotazione != null)
            {
                _context.Prenotazioni.Remove(prenotazione);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrenotazioneExists(int id)
        {
            return _context.Prenotazioni.Any(e => e.PrenotazioneId == id);
        }
    }
}
