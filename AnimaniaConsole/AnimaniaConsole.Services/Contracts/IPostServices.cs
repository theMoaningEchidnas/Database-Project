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
        IEnumerable<PostModel> SearchPostsFrom(string searchedText, int minPrice);
        IEnumerable<PostModel> SearchPostsTo(string searchedText, int maxPrice);
        IEnumerable<PostModel> SearchPostsFromTo(string searchedText, int minPrice,int maxPrice);
        IEnumerable<PostModel> GetActivePosts(int userId);
        IEnumerable<PostModel> GetAllDeactivetedPosts(int userId);
        void ActivatePost(int postId);
        void DeactivatePost(int postId, int userId);


        EditPostModel FindPostById(int postId);
        void VerifyPostOwnerId(int userIdOwnerOfPostToBeEdited, int loggedUserId);

    }
}