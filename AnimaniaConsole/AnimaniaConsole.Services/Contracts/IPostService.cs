using System.Collections.Generic;
using AnimaniaConsole.DTO.Models;

namespace AnimaniaConsole.Services.Contracts
{
    public interface IPostService
    {
        IEnumerable<PostModel> GetAll();
        void CreatePost(CreatePostModel createPostModel);
    }
}