using System.Collections.Generic;
using AnimaniaConsole.DTO;

namespace AnimaniaConsole.Services.Contracts
{
    public interface IPostService
    {
        IEnumerable<PostModel> GetAll();
    }
}