using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoGiuaKy.Data;
using DemoGiuaKy.Models;

namespace DemoGiuaKy.Controllers
{
    public class ResponsesController : Controller
    {
        private readonly DemoGiuaKyContext _context;

        public ResponsesController(DemoGiuaKyContext context)
        {
            _context = context;
        }

        // GET: Responses
        public async Task<IActionResult> Index()
        {
            var demoGiuaKyContext = _context.Response.Include(r => r.Product).Include(r => r.User);
            return View(await demoGiuaKyContext.ToListAsync());
        }

        // GET: Responses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Response == null)
            {
                return NotFound();
            }

            var response = await _context.Response
                .Include(r => r.Product)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.ResponeId == id);
            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        // GET: Responses/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductName");
            ViewData["UserId"] = new SelectList(_context.User, "UserID", "UserEmail");
            return View();
        }

        // POST: Responses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResponeId,ResponeDescription,UserId,ProductId")] Response response)
        {
            if (ModelState.IsValid)
            {
                _context.Add(response);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductName", response.ProductId);
            ViewData["UserId"] = new SelectList(_context.User, "UserID", "UserEmail", response.UserId);
            return View(response);
        }

        // GET: Responses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Response == null)
            {
                return NotFound();
            }

            var response = await _context.Response.FindAsync(id);
            if (response == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductName", response.ProductId);
            ViewData["UserId"] = new SelectList(_context.User, "UserID", "UserEmail", response.UserId);
            return View(response);
        }

        // POST: Responses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResponeId,ResponeDescription,UserId,ProductId")] Response response)
        {
            if (id != response.ResponeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(response);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResponseExists(response.ResponeId))
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
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductName", response.ProductId);
            ViewData["UserId"] = new SelectList(_context.User, "UserID", "UserEmail", response.UserId);
            return View(response);
        }

        // GET: Responses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Response == null)
            {
                return NotFound();
            }

            var response = await _context.Response
                .Include(r => r.Product)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.ResponeId == id);
            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        // POST: Responses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Response == null)
            {
                return Problem("Entity set 'DemoGiuaKyContext.Response'  is null.");
            }
            var response = await _context.Response.FindAsync(id);
            if (response != null)
            {
                _context.Response.Remove(response);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResponseExists(int id)
        {
          return (_context.Response?.Any(e => e.ResponeId == id)).GetValueOrDefault();
        }
    }
}
