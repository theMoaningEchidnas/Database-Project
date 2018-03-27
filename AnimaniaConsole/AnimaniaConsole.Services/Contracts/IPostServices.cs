using AnimaniaConsole.DTO.Models;
using System.Collections.Generic;

namespace AnimaniaConsole.Services.Contracts
{
    public interface IPostServices
    {
        IEnumerable<PostModel> GetAllMyPosts(int userId);
        void CreatePost(CreatePostModel createPostModel, int userId);
        IEnumerable<PostModel> SearchPosts(string searchedText);
        string PrintPostsToConsole(IEnumerable<PostModel> postsToPrint);
        string EditPostTitle(EditPostModel editPostModel);
        string EditPostDescription(EditPostModel editPostModel);
        string EditPostPrice(EditPostModel editPostModel);
        EditPostModel FindPostById(int postId);
        void VerifyPostOwnerId(int userIdOwnerOfPostToBeEdited, int loggedUserId);

    }
}