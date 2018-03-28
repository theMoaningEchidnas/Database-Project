﻿using AnimaniaConsole.DTO.Models;
using System.Collections.Generic;

namespace AnimaniaConsole.Services.Contracts
{
    public interface IPostService
    {
        IEnumerable<PostModel> ShowMyPosts(int userId);
        void CreatePost(CreatePostModel createPostModel, int userId);
        IEnumerable<PostModel> SearchPosts(string searchedText);
        string PrintPostsToConsole(IEnumerable<PostModel> postsToPrint);
        string EditPostTitle(EditPostModel editPostModel);
        string EditPostDescription(EditPostModel editPostModel);
        string EditPostPrice(EditPostModel editPostModel);
        IEnumerable<PostModel> SearchPostsFrom(string searchedText, int minPrice);
        IEnumerable<PostModel> SearchPostsTo(string searchedText, int maxPrice);
        IEnumerable<PostModel> SearchPostsFromTo(string searchedText, int minPrice,int maxPrice);



    }
}