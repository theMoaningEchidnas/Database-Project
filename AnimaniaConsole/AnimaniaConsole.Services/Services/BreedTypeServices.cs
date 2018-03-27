using AnimaniaConsole.Data;
using System;
using System.Linq;
using AnimaniaConsole.Services.Contracts;

namespace AnimaniaConsole.Services.Services
{
    public class BreedTypeServices: IBreedTypeServices
    {
        public int GetBreedTypeIdByBreedTypeName(IAnimaniaConsoleContext context, string breedTypeName)
        {
            var breedTypeId = context.BreedTypes
                .Where(x => x.BreedTypeName == breedTypeName)
                .Select(x => x.Id)
                .SingleOrDefault();
            if (breedTypeId == 0)
            {
                throw new ArgumentNullException("Such type of Breed does not exist");
            }
            return breedTypeId;

        }

    }
}
