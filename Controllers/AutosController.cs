﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prueba_ABM.Models;

namespace Prueba_ABM.Controllers
{
  public class AutosController : Controller
  {
    private readonly Prueba_ABMContext _context;

    public AutosController(Prueba_ABMContext context)
    {
      _context = context;
    }

    // GET: Autos
    public async Task<IActionResult> Index()
    {
      return View(await _context.Auto.ToListAsync());
    }

    public JsonResult apiGET()
    {
      var autos = _context.Auto
        .Include("Modelo.Marca")
        .Select(a => new
        {
          a.Id,
          marcaId = a.Modelo.Marca.Id,
          marca = a.Modelo.Marca.Nombre,
          modeloId = a.Modelo.Id,
          modelo = a.Modelo.Nombre,
          a.Precio,
          fecha = a.FechaAdquisicion
        });

      return Json(autos);
    }

    public JsonResult apiGETUNIQUE(int id)
    {
      var auto = _context.Auto
        .Include("Modelo.Marca")
        .Select(a => new
        {
          a.Id,
          marcaId = a.Modelo.Marca.Id,
          marca = a.Modelo.Marca.Nombre,
          modeloId = a.Modelo.Id,
          modelo = a.Modelo.Nombre,
          a.Precio,
          fecha = a.FechaAdquisicion
        }).Where(a => a.Id == id);

      if (auto == null)
      {
        return Json(NotFound());
      }

      return Json(auto);
    }

    [HttpPost]
    public async Task<JsonResult> apiDELETE(int id)
    {
      var auto = await _context.Auto.FindAsync(id);
      _context.Auto.Remove(auto);
      await _context.SaveChangesAsync();
      return Json("OK");
    }

    public async Task<JsonResult> apiCREATE(decimal precio, int modelo, DateTime fecha)
    {
      Auto auto = new Auto(precio, modelo, fecha);
      _context.Auto.Add(auto);
      await _context.SaveChangesAsync();

      JsonResult jsauto = apiGETUNIQUE(auto.Id);

      return jsauto;
    }

    [HttpPost]
    public async Task<JsonResult> apiEDIT(int identificador, int precio, int modelo, DateTime fecha)
    {

      var auto = await _context.Auto
          .FirstOrDefaultAsync(a => a.Id == identificador);

      auto.Precio = precio;
      auto.ModeloId = modelo;
      auto.FechaAdquisicion = fecha;

      //Falta validacion de backend

      try
      {
        _context.Update(auto);
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!AutoExists(auto.Id))
        {
          return Json(NotFound());
        }
        else
        {
          throw;
        }
      }

      return apiGETUNIQUE(identificador);
    }

    // GET: Autos/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var auto = await _context.Auto
          .FirstOrDefaultAsync(m => m.Id == id);
      if (auto == null)
      {
        return NotFound();
      }

      return View(auto);
    }

    // GET: Autos/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Autos/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Precio,FechaAdquisicion,ModeloId")] Auto auto)
    {
      if (ModelState.IsValid)
      {
        _context.Add(auto);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(auto);
    }

    // GET: Autos/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var auto = await _context.Auto.FindAsync(id);
      if (auto == null)
      {
        return NotFound();
      }
      return View(auto);
    }

    // POST: Autos/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Precio,FechaAdquisicion,ModeloId")] Auto auto)
    {
      if (id != auto.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(auto);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!AutoExists(auto.Id))
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
      return View(auto);
    }

    // GET: Autos/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var auto = await _context.Auto
          .FirstOrDefaultAsync(m => m.Id == id);
      if (auto == null)
      {
        return NotFound();
      }

      return View(auto);
    }

    // POST: Autos/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var auto = await _context.Auto.FindAsync(id);
      _context.Auto.Remove(auto);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool AutoExists(int id)
    {
      return _context.Auto.Any(e => e.Id == id);
    }
  }
}
