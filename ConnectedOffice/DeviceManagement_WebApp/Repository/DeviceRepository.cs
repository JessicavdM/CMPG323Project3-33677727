using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    public class DeviceRepository : GenericRepository<Device>, IDeviceRepository
    {
        public DeviceRepository(ConnectedOfficeContext context) : base(context)
        {
        }

        public override IEnumerable<Device> GetAll()
        {
            var connectedOfficeContext = _context.Device.Include(d => d.Category).Include(d => d.Zone);
            return connectedOfficeContext.ToList();
        }
    }
}
