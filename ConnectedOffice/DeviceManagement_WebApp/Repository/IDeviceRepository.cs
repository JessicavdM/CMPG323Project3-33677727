using DeviceManagement_WebApp.Models;
using System.Collections.Generic;

namespace DeviceManagement_WebApp.Repository
{
    public interface IDeviceRepository : IGenericRepository<Device>
    {
        IEnumerable<Category> GetCategory();
        IEnumerable<Zone> GetZone();
    }
}
