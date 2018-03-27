using AnimaniaConsole.Data;

namespace AnimaniaConsole.Services.Contracts
{
    public interface ILocationServices
    {
        int GetLocationIdByLocationName(IAnimaniaConsoleContext context, string locationName);
    }
}