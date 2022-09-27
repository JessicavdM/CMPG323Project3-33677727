using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    public class DeviceRepository : GenericRepository<Device>, IDeviceRepository
    {
        public DeviceRepository(ConnectedOfficeContext context) : base(context)
        {
        }

        //Gets all Devices gets their related Categories and Zones
        public override IEnumerable<Device> GetAll()
        {
            var connectedOfficeContext = _context.Device.Include(d => d.Category).Include(d => d.Zone);
            return connectedOfficeContext.ToList();
        }

        //Gets a Device by ID and gets related Category and Zone
        public override Device GetById(Guid? id)
        {
            return _context.Device
                .Include(d => d.Category)
                .Include(d => d.Zone)
                .FirstOrDefault(m => m.DeviceId == id);
        }

        //Returns an Enumarable object of Categories related to the DBContext
        public IEnumerable<Category> GetCategory()
        {
            return _context.Category;
        }

        //Returns an Enumarable object of Zones related to the DBContext
        public IEnumerable<Zone> GetZone()
        {
            return _context.Zone;
        }
    }
}
