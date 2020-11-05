using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sys_Recom_EComm_PC_comp.Data;
using Sys_Recom_EComm_PC_comp.Models;

namespace Sys_Recom_EComm_PC_comp.Controllers
{
    public class KeywordProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KeywordProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: KeywordProducts
        public async Task<IActionResult> Index()
        {
            return View(await _context.KeywordProducts.ToListAsync());
        }

        // GET: KeywordProducts/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keywordProduct = await _context.KeywordProducts
                .FirstOrDefaultAsync(m => m.KeywordProductID == id);
            if (keywordProduct == null)
            {
                return NotFound();
            }

            return View(keywordProduct);
        }

        // GET: KeywordProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KeywordProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KeywordProductID,ProductID,KeywordID")] KeywordProduct keywordProduct)
        {
            if (ModelState.IsValid)
            {
                keywordProduct.KeywordProductID = Guid.NewGuid();
                _context.Add(keywordProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(keywordProduct);
        }

        // GET: KeywordProducts/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keywordProduct = await _context.KeywordProducts.FindAsync(id);
            if (keywordProduct == null)
            {
                return NotFound();
            }
            return View(keywordProduct);
        }

        // POST: KeywordProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("KeywordProductID,ProductID,KeywordID")] KeywordProduct keywordProduct)
        {
            if (id != keywordProduct.KeywordProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(keywordProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KeywordProductExists(keywordProduct.KeywordProductID))
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
            return View(keywordProduct);
        }

        // GET: KeywordProducts/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keywordProduct = await _context.KeywordProducts
                .FirstOrDefaultAsync(m => m.KeywordProductID == id);
            if (keywordProduct == null)
            {
                return NotFound();
            }

            return View(keywordProduct);
        }

        // POST: KeywordProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var keywordProduct = await _context.KeywordProducts.FindAsync(id);
            _context.KeywordProducts.Remove(keywordProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KeywordProductExists(Guid id)
        {
            return _context.KeywordProducts.Any(e => e.KeywordProductID == id);
        }
    }
}
