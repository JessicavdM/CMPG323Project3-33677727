using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repository;
using System.Linq.Expressions;

namespace DeviceManagement_WebApp.Controllers
{
    public class ZonesController : Controller
    {
        //creating an instance of the IZoneRepository
        private readonly IZoneRepository _zoneRepository;

        public ZonesController(IZoneRepository zoneRepository)
        {
            _zoneRepository = zoneRepository;
        }

        // Get all Zones
        public async Task<IActionResult> Index()
        {
            return View(_zoneRepository.GetAll());
        }

        // Get zone by ID
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zone = _zoneRepository.GetById(id);

            if (zone == null)
            {
                return NotFound();
            }

            return View(zone);
        }

        // Get Zone to create
        public IActionResult Create()
        {
            return View();
        }

        // Create a new Zone
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZoneId,ZoneName,ZoneDescription,DateCreated")] Zone zone)
        {
            zone.ZoneId = Guid.NewGuid();
            _zoneRepository.Add(zone);
            await _zoneRepository.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // Retrieves the Zone by ID in preparation for an Edit
        public async Task<IActionResult> Edit(Guid? id)
        {
            return await Details(id);
        }

        // Changes the Zone provided to the method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ZoneId,ZoneName,ZoneDescription,DateCreated")] Zone zone)
        {
            if (id != zone.ZoneId)
            {
                return NotFound();
            }

            try
            {
                _zoneRepository.Update(zone);
                await _zoneRepository.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZoneExists(zone.ZoneId))
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

        // Retrieves Zone to be deleted by ID
        public async Task<IActionResult> Delete(Guid? id)
        {
            return await Details(id);
        }

        // Deletes a Zone by ID
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var zone = _zoneRepository.GetById(id);
            _zoneRepository.Remove(zone);
            await _zoneRepository.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        //Check to see if a Zone exists for the given ID
        private bool ZoneExists(Guid id)
        {
            if(_zoneRepository.Find(e => e.ZoneId == id) != null)
                return true;

            return false;
        }
    }
}
