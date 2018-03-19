using System.Collections.Generic;
using AnimaniaConsole.Data;
using AnimaniaConsole.DTO;
using AnimaniaConsole.Services.Contracts;
using AutoMapper.QueryableExtensions;

namespace AnimaniaConsole.Services.Services

{
    public class PostService : IPostService
    {
        private readonly IAnimaniaConsoleContext context;

        public PostService(IAnimaniaConsoleContext context)
        {
            this.context = context;
        }

        public IEnumerable<PostModel> GetAll()
        {
            var posts = this.context.Posts.ProjectTo<PostModel>();
            return posts;
        }

    }
}
