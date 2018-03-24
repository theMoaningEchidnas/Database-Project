using AnimaniaConsole.DTO.Models;
using System.Collections.Generic;

namespace AnimaniaConsole.Services.Contracts
{
    public interface IPostService
    {
        IEnumerable<PostModel> GetAll();
        void CreatePost(CreatePostModel createPostModel);
        IEnumerable<PostModel> SearchPosts(string searchedText);
    }
}