using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UrunSiparis.Data;
using UrunSiparis.Models;

namespace UrunSiparis.Controllers
{
    public class UrunSiparisController : Controller
    {
        private readonly UrunSiparisContext _context;

        public UrunSiparisController(UrunSiparisContext context)
        {
            _context = context;
        }

        // GET: UrunSiparis
        public async Task<IActionResult> Index()
        {
            return View(await _context.UrunSiparisModel.ToListAsync());
        }

        // GET: UrunSiparis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var urunSiparisModel = await _context.UrunSiparisModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (urunSiparisModel == null)
            {
                return NotFound();
            }

            return View(urunSiparisModel);
        }

        // GET: UrunSiparis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UrunSiparis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Adress,City,Country")] UrunSiparisModel urunSiparisModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(urunSiparisModel);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Öğe başarıyla eklendi!";
                return RedirectToAction(nameof(Index));
            }
            return View(urunSiparisModel);
        }

        // GET: UrunSiparis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var urunSiparisModel = await _context.UrunSiparisModel.FindAsync(id);
            if (urunSiparisModel == null)
            {
                return NotFound();
            }
            return View(urunSiparisModel);
        }

        // POST: UrunSiparis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Adress,City,Country")] UrunSiparisModel urunSiparisModel)
        {
            if (id != urunSiparisModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(urunSiparisModel);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Öğe başarıyla güncellendi!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UrunSiparisModelExists(urunSiparisModel.Id))
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
            return View(urunSiparisModel);
        }

        // GET: UrunSiparis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var urunSiparisModel = await _context.UrunSiparisModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (urunSiparisModel == null)
            {
                return NotFound();
            }

            return View(urunSiparisModel);
        }

        // POST: UrunSiparis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var urunSiparisModel = await _context.UrunSiparisModel.FindAsync(id);
            _context.UrunSiparisModel.Remove(urunSiparisModel);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Öğe başarıyla silindi!";
            return RedirectToAction(nameof(Index));
        }

        private bool UrunSiparisModelExists(int id)
        {
            return _context.UrunSiparisModel.Any(e => e.Id == id);
        }
    }
}
