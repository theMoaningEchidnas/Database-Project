using System;
using System.Linq;
using AnimaniaConsole.Data;
using AnimaniaConsole.Services.Contracts;

namespace AnimaniaConsole.Services.Services
{
    public class AnimalTypeServices: IAnimalTypeServices
    {
        public byte GetAnimalTypeIdByAnimalTypeName(IAnimaniaConsoleContext context, string animalTypeName)
        {
            var animalTypeId = context.AnimalTypes
                .Where(x => x.AnimalTypeName == animalTypeName)
                .Select(x => x.Id)
                .SingleOrDefault();
            if (animalTypeId == 0)
            {
                throw new ArgumentException("Such type of Animal does not exist");
            }
            return animalTypeId;

        }
    }
}
