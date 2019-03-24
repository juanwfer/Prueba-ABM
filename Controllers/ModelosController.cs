using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prueba_ABM.Models;

namespace Prueba_ABM.Controllers
{
  public class ModelosController : Controller
  {
    private readonly Prueba_ABMContext _context;

    public ModelosController(Prueba_ABMContext context)
    {
      _context = context;
    }

    // GET: Modelos
    public async Task<IActionResult> Index()
    {
      return View(await _context.Modelo.ToListAsync());
    }

    // GET: Modelos/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var modelo = await _context.Modelo
          .FirstOrDefaultAsync(m => m.Id == id);
      if (modelo == null)
      {
        return NotFound();
      }

      return View(modelo);
    }

    // GET: Modelos/Create
    public IActionResult Create()
    {
      PopulateMarcasDropDownList();
      return View();
    }

    // POST: Modelos/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,MarcaId")] Modelo modelo)
    {
      if (ModelState.IsValid)
      {
        _context.Add(modelo);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(modelo);
    }

    // GET: Modelos/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var modelo = await _context.Modelo.FindAsync(id);
      if (modelo == null)
      {
        return NotFound();
      }
      return View(modelo);
    }

    // POST: Modelos/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion")] Modelo modelo)
    {
      if (id != modelo.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(modelo);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!ModeloExists(modelo.Id))
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
      return View(modelo);
    }

    // GET: Modelos/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var modelo = await _context.Modelo
          .FirstOrDefaultAsync(m => m.Id == id);
      if (modelo == null)
      {
        return NotFound();
      }

      return View(modelo);
    }

    // POST: Modelos/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var modelo = await _context.Modelo.FindAsync(id);
      _context.Modelo.Remove(modelo);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool ModeloExists(int id)
    {
      return _context.Modelo.Any(e => e.Id == id);
    }

    private void PopulateMarcasDropDownList(object selectedMarca = null)
    {
      var marcasQuery = from m in _context.Marca
                             orderby m.Nombre
                             select m;
      ViewBag.MarcaID = new SelectList(marcasQuery, "MarcaId", "Nombre", selectedMarca);
    }
  }
}
