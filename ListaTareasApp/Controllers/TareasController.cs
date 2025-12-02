using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ListaTareasApp.Data;
using ListaTareasApp.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ListaTareasApp.Controllers
{
    [Authorize]
    public class TareasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TareasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tareas
        public async Task<IActionResult> Index(string prioridad)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var tareas = _context.Tareas.Where(t => t.UsuarioId == userId);

            if (!string.IsNullOrEmpty(prioridad))
            {
                tareas = tareas.Where(t => t.Prioridad == prioridad);
            }

            return View(await tareas.OrderByDescending(t => t.FechaCreacion).ToListAsync());
        }

        // GET: Tareas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tareas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tarea tarea)
        {
            // Remover validaciones que no necesitamos
            ModelState.Remove("UsuarioId");
            ModelState.Remove("Id");

            if (ModelState.IsValid)
            {
                tarea.UsuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
                tarea.FechaCreacion = DateTime.Now;
                tarea.Completada = false;

                _context.Add(tarea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Si hay errores, mostrarlos
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }

            return View(tarea);
        }

        // GET: Tareas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var tarea = await _context.Tareas.FirstOrDefaultAsync(t => t.Id == id && t.UsuarioId == userId);

            if (tarea == null)
            {
                return NotFound();
            }
            return View(tarea);
        }

        // POST: Tareas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Tarea tarea)
        {
            if (id != tarea.Id)
            {
                return NotFound();
            }

            ModelState.Remove("UsuarioId");

            if (ModelState.IsValid)
            {
                try
                {
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var tareaExistente = await _context.Tareas.FirstOrDefaultAsync(t => t.Id == id && t.UsuarioId == userId);

                    if (tareaExistente == null)
                    {
                        return NotFound();
                    }

                    tareaExistente.Titulo = tarea.Titulo;
                    tareaExistente.Descripcion = tarea.Descripcion;
                    tareaExistente.Completada = tarea.Completada;
                    tareaExistente.Prioridad = tarea.Prioridad;

                    _context.Update(tareaExistente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TareaExists(tarea.Id))
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
            return View(tarea);
        }

        // GET: Tareas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var tarea = await _context.Tareas
                .FirstOrDefaultAsync(t => t.Id == id && t.UsuarioId == userId);

            if (tarea == null)
            {
                return NotFound();
            }

            return View(tarea);
        }

        // POST: Tareas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var tarea = await _context.Tareas.FirstOrDefaultAsync(t => t.Id == id && t.UsuarioId == userId);

            if (tarea != null)
            {
                _context.Tareas.Remove(tarea);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool TareaExists(int id)
        {
            return _context.Tareas.Any(e => e.Id == id);
        }
    }
}