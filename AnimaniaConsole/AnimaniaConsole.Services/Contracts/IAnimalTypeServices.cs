using AnimaniaConsole.Data;

namespace AnimaniaConsole.Services.Contracts
{
    public interface IAnimalTypeServices
    {
        byte GetAnimalTypeIdByAnimalTypeName(IAnimaniaConsoleContext context, string animalTypeName);
    }
}
