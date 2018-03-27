using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Models.Models;


namespace AnimaniaConsole.Services.Contracts
{
    internal interface IAnimalService
    {
        Animal CreateAnimal(AnimalModel animalModel);
    }
}