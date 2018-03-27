using AnimaniaConsole.Data;
using AnimaniaConsole.Services.Contracts;
using System;
using System.Linq;

namespace AnimaniaConsole.Services.Services
{
    public class LocationServices : ILocationServices
    {
        public int GetLocationIdByLocationName(IAnimaniaConsoleContext context, string locationName)
        {
            var locationId = context.Locations
                .Where(x => x.LocationName == locationName)
                .Select(x => x.Id)
                .SingleOrDefault();
            if (locationId == 0)
            {
                throw new ArgumentException("Such Location does not exist");
            }
            return locationId;
        }

    }
}
