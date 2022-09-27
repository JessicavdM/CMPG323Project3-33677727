using DeviceManagement_WebApp.Models;
using System.Collections.Generic;

namespace DeviceManagement_WebApp.Repository
{
    public interface IDeviceRepository : IGenericRepository<Device>
    {
        //Returns an Enumarable object of Categories related to the DBContext
        IEnumerable<Category> GetCategory();

        //Returns an Enumarable object of Zones related to the DBContext
        IEnumerable<Zone> GetZone();
    }
}
