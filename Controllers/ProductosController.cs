﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bodega.Config;
using Bodega.Models;

namespace Bodega.Controllers
{
    public class ProductosController : Controller
    {
        private readonly BodegaAppContext _context;

        public ProductosController(BodegaAppContext context)
        {
            _context = context;
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Productos.ToListAsync());
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productosModel = await _context.Productos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productosModel == null)
            {
                return NotFound();
            }

            return View(productosModel);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,UnidadMedida,RegSanitario,CodigoBarras")] ProductosModel productosModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productosModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productosModel);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productosModel = await _context.Productos.FindAsync(id);
            if (productosModel == null)
            {
                return NotFound();
            }
            return View(productosModel);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,UnidadMedida,RegSanitario,CodigoBarras")] ProductosModel productosModel)
        {
            if (id != productosModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productosModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductosModelExists(productosModel.Id))
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
            return View(productosModel);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productosModel = await _context.Productos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productosModel == null)
            {
                return NotFound();
            }

            return View(productosModel);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productosModel = await _context.Productos.FindAsync(id);
            if (productosModel != null)
            {
                _context.Productos.Remove(productosModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductosModelExists(int id)
        {
            return _context.Productos.Any(e => e.Id == id);
        }
    }
}
