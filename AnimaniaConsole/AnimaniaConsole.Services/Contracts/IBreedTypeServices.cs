using AnimaniaConsole.Data;

namespace AnimaniaConsole.Services.Contracts
{
    public interface IBreedTypeServices
    {
        int GetBreedTypeIdByBreedTypeName(IAnimaniaConsoleContext context, string breedTypeName);

    }
}