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

namespace DeviceManagement_WebApp.Controllers
{
    public class DevicesController : Controller
    {
        //Initiate an instance of IDeviceRepository
        private readonly IDeviceRepository _deviceRepository;

        public DevicesController(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;   
        }

        // Get all Devices
        public async Task<IActionResult> Index()
        {
            return View(_deviceRepository.GetAll());
        }

        // Get a Device by ID
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = _deviceRepository.GetById(id);

            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // Get an empty Device to create a new Device
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_deviceRepository.GetCategory(), "CategoryId", "CategoryName");
            ViewData["ZoneId"] = new SelectList(_deviceRepository.GetZone(), "ZoneId", "ZoneName");
            return View();
        }

        // Create a new Device
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            device.DeviceId = Guid.NewGuid();
            _deviceRepository.Add(device);
            await _deviceRepository.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Retrieves the Device by ID in preparation for an Edit
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = _deviceRepository.GetById(id);

            if (device == null)
            {
                return NotFound();
            }
            
            ViewData["CategoryId"] = new SelectList(_deviceRepository.GetCategory(), "CategoryId", "CategoryName", device.CategoryId);
            ViewData["ZoneId"] = new SelectList(_deviceRepository.GetZone(), "ZoneId", "ZoneName", device.ZoneId);

            return View(device);
        }

        // Changes the Device provided to the method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            if (id != device.DeviceId)
            {
                return NotFound();
            }
            try
            {
                _deviceRepository.Update(device);
                await _deviceRepository.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceExists(device.DeviceId))
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

        // Retrieves Device to be deleted by ID
        public async Task<IActionResult> Delete(Guid? id)
        {
            return await Details(id);
        }

        // Deletes a Device by ID
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var device = _deviceRepository.GetById(id);
            _deviceRepository.Remove(device);
            await _deviceRepository.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Check to see if a Device exists for the given ID
        private bool DeviceExists(Guid id)
        {
            if (_deviceRepository.Find(e => e.DeviceId == id) != null)
                return true;

            return false;
        }
    }
}
