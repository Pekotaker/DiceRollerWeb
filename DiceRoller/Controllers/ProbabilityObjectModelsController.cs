using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DiceRoller.Data;
using DiceRoller.Models;
using Microsoft.AspNetCore.Http;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json;


namespace DiceRoller.Controllers
{
    public class ProbabilityObjectModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProbabilityObjectModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProbabilityObjectModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProbabilityObjectModel.ToListAsync());
        }

        // GET: ProbabilityObjectModels/Search
        public async Task<IActionResult> Search(string searchString)
        {
            var probabilityObjectModels = from m in _context.ProbabilityObjectModel
                                           select m;

            System.Diagnostics.Debug.WriteLine("Search string: " + searchString);

            if (!System.String.IsNullOrEmpty(searchString))
            {
                probabilityObjectModels = probabilityObjectModels.Where(s => s.ObjectName.Contains(searchString));
                // log search string
                Console.WriteLine("Search string: " + searchString);
            }

            return View(await probabilityObjectModels.ToListAsync());
        }

        // GET: ProbabilityObjectModels/Roller?ObjectId=1
        public async Task<IActionResult> Roller(int? ObjectId)
        {
            if (ObjectId == null)
            {
                return NotFound();
            }

            var probabilityObjectModel = await _context.ProbabilityObjectModel.FindAsync(ObjectId);
            if (probabilityObjectModel == null)
            {
                return NotFound();
            }

            return View(probabilityObjectModel);
        }

        // POST: ProbabilityObjectModels/Roll?ObjectId=1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Roller(int ObjectId)
        {
            System.Diagnostics.Debug.WriteLine("Rolling dice for object ID: " + ObjectId);
            var probabilityObjectModel = await _context.ProbabilityObjectModel.FindAsync(ObjectId);
            if (probabilityObjectModel == null)
            {
                return NotFound();
            }

            // roll the dice
            Random random = new Random();
            int roll = random.Next(1, probabilityObjectModel.NumberOfStates + 1);
            probabilityObjectModel.CurrentState = roll;

            return View(probabilityObjectModel);
        }
      

        // GET: ProbabilityObjectModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var probabilityObjectModel = await _context.ProbabilityObjectModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (probabilityObjectModel == null)
            {
                return NotFound();
            }

            return View(probabilityObjectModel);
        }

        // GET: ProbabilityObjectModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProbabilityObjectModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ObjectName,NumberOfStates,StateLabels,StateProbabilities,StateViews")] ProbabilityObjectModel probabilityObjectModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(probabilityObjectModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(probabilityObjectModel);
        }

        // GET: ProbabilityObjectModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var probabilityObjectModel = await _context.ProbabilityObjectModel.FindAsync(id);
            if (probabilityObjectModel == null)
            {
                return NotFound();
            }
            return View(probabilityObjectModel);
        }

        // POST: ProbabilityObjectModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ObjectName,NumberOfStates,StateLabels,StateProbabilities,StateViews")] ProbabilityObjectModel probabilityObjectModel)
        {
            if (id != probabilityObjectModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(probabilityObjectModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProbabilityObjectModelExists(probabilityObjectModel.Id))
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
            return View(probabilityObjectModel);
        }

        // GET: ProbabilityObjectModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var probabilityObjectModel = await _context.ProbabilityObjectModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (probabilityObjectModel == null)
            {
                return NotFound();
            }

            return View(probabilityObjectModel);
        }

        // POST: ProbabilityObjectModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var probabilityObjectModel = await _context.ProbabilityObjectModel.FindAsync(id);
            if (probabilityObjectModel != null)
            {
                _context.ProbabilityObjectModel.Remove(probabilityObjectModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProbabilityObjectModelExists(int id)
        {
            return _context.ProbabilityObjectModel.Any(e => e.Id == id);
        }
    }
}
