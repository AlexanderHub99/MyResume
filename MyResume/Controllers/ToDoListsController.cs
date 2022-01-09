#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyResume.Data;
using MyResume.Models;

namespace MyResume.Controllers
{
    public class ToDoListsController : Controller
    {
        private readonly WebToDoListContext _context;

        public ToDoListsController(WebToDoListContext context)
        {
            _context = context;
        }

        // GET: ToDoLists
        public async Task<IActionResult> Index(string taskPriority, string taskData, string Completed)
        {
            IQueryable<string> genreQuery = from m in _context.ToDoList
                                            orderby m.priority
                                            select m.priority;

            IQueryable<bool> completed = from m in _context.ToDoList
                                         orderby m.CompletedNotCompleted
                                         select m.CompletedNotCompleted;

            var tasks = from m in _context.ToDoList
                        select m;

            if (!string.IsNullOrEmpty(taskPriority))
            {
                tasks = tasks.Where(s => s.dateOfCompletion == DateTime.Parse(taskPriority));
            }

            if (!string.IsNullOrEmpty(taskData))
            {
                tasks = tasks.Where(s => s.priority == taskData);
            }

            if (!string.IsNullOrEmpty(Completed))
            {
                tasks = tasks.Where(s => s.CompletedNotCompleted == bool.Parse(Completed));
            }

            var toDoListGenreVM = new ToDoListGenreViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                ToDoLists = await tasks.ToListAsync()
            };
            return View(toDoListGenreVM);
        }

        // GET: ToDoLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoList = await _context.ToDoList
                .FirstOrDefaultAsync(m => m.id == id);
            if (toDoList == null)
            {
                return NotFound();
            }

            return View(toDoList);
        }

        // GET: ToDoLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ToDoLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Task,dateOfCompletion,priority")] ToDoList toDoList)
        {
            
            if (ModelState.IsValid)
            {
                _context.Add(toDoList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(toDoList);
        }

        // GET: ToDoLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoList = await _context.ToDoList.FindAsync(id);
            if (toDoList == null)
            {
                return NotFound();
            }
            return View(toDoList);
        }

        // POST: ToDoLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Task,dateOfCompletion,priority,CompletedNotCompleted")] ToDoList toDoList)
        {
            if (id != toDoList.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toDoList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToDoListExists(toDoList.id))
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
            return View(toDoList);
        }

        // GET: ToDoLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoList = await _context.ToDoList
                .FirstOrDefaultAsync(m => m.id == id);
            if (toDoList == null)
            {
                return NotFound();
            }

            return View(toDoList);
        }

        // POST: ToDoLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toDoList = await _context.ToDoList.FindAsync(id);
            _context.ToDoList.Remove(toDoList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToDoListExists(int id)
        {
            return _context.ToDoList.Any(e => e.id == id);
        }
    }
}
