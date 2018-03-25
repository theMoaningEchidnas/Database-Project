using AnimaniaConsole.DTO.Models;
using System.Collections.Generic;

namespace AnimaniaConsole.Services.Contracts
{
    public interface IPostService
    {
        IEnumerable<PostModel> GetAllPosts();
        void CreatePost(CreatePostModel createPostModel, int userId);
        IEnumerable<PostModel> SearchPosts(string searchedText);
    }
}