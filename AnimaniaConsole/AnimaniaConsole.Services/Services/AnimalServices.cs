using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Models.Models;
using AnimaniaConsole.Services.Contracts;

namespace AnimaniaConsole.Services.Services
{
    public class AnimalServices : IAnimalService
    {
        public Animal CreateAnimal(AnimalModel animalModel)
        {
            var animal = AutoMapper.Mapper.Map<Animal>(animalModel);
            return animal;

        }
    }
}
