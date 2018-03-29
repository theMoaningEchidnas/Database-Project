using AnimaniaConsole.Data;

namespace AnimaniaConsole.Services.Contracts
{
    public interface IBreedTypeServices
    {
        int GetBreedTypeIdByBreedTypeName(string breedTypeName);

        void LoadBreedsFromJSON(string path, string animal);
    }
}