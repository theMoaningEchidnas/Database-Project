using AnimaniaConsole.Models.Models;
using AnimaniaConsole.DTO.Models;

namespace AnimaniaConsole.Services.Contracts
{
    internal interface IAnimalService
    {
        Animal CreateAnimal(AnimalModel animalModel);
    }
}