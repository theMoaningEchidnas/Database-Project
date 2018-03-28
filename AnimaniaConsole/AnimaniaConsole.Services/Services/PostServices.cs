using AnimaniaConsole.Data;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Models.Models;
using AnimaniaConsole.Services.Contracts;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimaniaConsole.Services.Services

{
    public class PostServices : IPostServices
    {
        private readonly IAnimaniaConsoleContext context;
        private readonly ILocationServices locationServices;
        private readonly IAnimalTypeServices animalTypeServices;
        private readonly IBreedTypeServices breedTypeServices;

        public PostServices(IAnimaniaConsoleContext context, ILocationServices locationServices, IAnimalTypeServices animalTypeServices, IBreedTypeServices breedTypeServices)
        {
            this.context = context;
            this.locationServices = locationServices;
            this.animalTypeServices = animalTypeServices;
            this.breedTypeServices = breedTypeServices;
        }

        public void CreatePost(CreatePostModel createPostModel, int userId)
        {
            var locationId = locationServices.GetLocationIdByLocationName(context, createPostModel.LocationName);
            var animalTypeId = animalTypeServices.GetAnimalTypeIdByAnimalTypeName(context, createPostModel.AnimalTypeName);
            var breedTypeId = breedTypeServices.GetBreedTypeIdByBreedTypeName(context, createPostModel.BreedTypeName);

            var animal = new Animal
            {
                AnimalName = createPostModel.AnimalName,
                Birthday = DateTime.Parse(createPostModel.Birthday.ToString()),
                AnimalTypeId = animalTypeId,
                BreedTypeId = breedTypeId,
                LocationId = locationId,
                UserId = userId
            };

            var postToCreate = AutoMapper.Mapper.Map<Post>(createPostModel);
            postToCreate.Animal = animal;
            postToCreate.User = context.Users.Find(userId);

            this.context.Posts.Add(postToCreate);
            this.context.SaveChanges();
        }

        //public IList<Post> GetAllPosts(UserSessionModel userSession)
        //{
        //    var posts = this.context.Posts.Where(x => x.UserId == userSession.Id).ToList();
        //    return posts;
        //}

        public IEnumerable<PostModel> GetAllMyPosts(int userId)
        {
            var posts = this.context.Posts.Where(x => x.UserId == userId).ProjectTo<PostModel>();
            return posts;
        }

        public IEnumerable<PostModel> SearchPosts(string searchedText)
        {
            var posts = this.context.Posts.ProjectTo<PostModel>();
            var searchResult = posts.Where(x => x.Title.Contains(searchedText) || x.Description.Contains(searchedText)).ToList();

            return searchResult;
        }
        public IEnumerable<PostModel> SearchPostsFrom(string searchedText,int minPrice)
        {
            var searchResult = this.SearchPosts(searchedText);
            var postsInThePriceRange = searchResult.Where(x => x.Price >= minPrice).ToList();
            return postsInThePriceRange;
        }
        public IEnumerable<PostModel> SearchPostsTo(string searchedText, int maxPrice)
        {
            var searchResult = this.SearchPosts(searchedText);
            var postsInThePriceRange = searchResult.Where(x => x.Price <= maxPrice).ToList();
            return postsInThePriceRange;
        }
        public IEnumerable<PostModel> SearchPostsFromTo(string searchedText, int minPrice,int maxPrice)
        {
            var searchResult = this.SearchPosts(searchedText);
            var postsInThePriceRange = searchResult.Where(x => x.Price <= maxPrice && x.Price >=minPrice).ToList();
            return postsInThePriceRange;
        }

        public string PrintPostsToConsole(IEnumerable<PostModel> listOfFoundPosts)
        {
            var numberOfPostsFound = listOfFoundPosts.Count();
            var searchResult = new StringBuilder();
            searchResult = listOfFoundPosts.Any() ?
                searchResult.AppendLine($"{numberOfPostsFound} posts found.") : searchResult.AppendLine("No posts found!");

            foreach (var foundPost in listOfFoundPosts)
            {
                var location = context.Locations.Where(x => x.Id == foundPost.Animal.LocationId)
                    .Select(x => x.LocationName).Single();
                searchResult.AppendLine(string.Format(
                    "#PostId: {0}{5}" +
                    "#Title: {1}{5}" +
                    "#Description: {2}{5}" +
                    "#Price: {3}{5}" +
                    "#Location: {4}{5}" +
                    "--------------------{5}",
                    foundPost.Id, foundPost.Title, foundPost.Description, foundPost.Price, location, Environment.NewLine));
            }
            return searchResult.ToString();
        }

        public string EditPostTitle(EditPostModel editPostModel)
        {
            var postForEdit = this.context.Posts.Find(editPostModel.Id);
            postForEdit.Title = editPostModel.Title;
            context.SaveChanges();

            return "Post Title was successfully edited";
        }

        public string EditPostDescription(EditPostModel editPostModel)
        {
            var postForEdit = this.context.Posts.Find(editPostModel.Id);
            postForEdit.Description = editPostModel.Description;
            context.SaveChanges();

            return "Post Description was successfully edited";
        }

        public string EditPostPrice(EditPostModel editPostModel)
        {
            var postForEdit = this.context.Posts.Find(editPostModel.Id);
            postForEdit.Price = editPostModel.Price;
            context.SaveChanges();

            return "Post Price was successfully edited";

        }

        public EditPostModel FindPostById(int postId)
        {
            var post = context.Posts.Find(postId);
            if (post == null)
            {
                throw new ArgumentException("Such post doesn't exist. Please check the id and try again!");
            }

            if (post.Status == false)
            {
                throw new ArgumentException("This post has been removed!");
            }

            var postToEdit = AutoMapper.Mapper.Map<EditPostModel>(post);

            return postToEdit;
        }

        public void VerifyPostOwnerId(int userIdOwnerOfPostToBeEdited, int loggedUserId)
        {
            if (loggedUserId != userIdOwnerOfPostToBeEdited)
            {
                throw new ArgumentException("Post Id provided is not correct. Please check the id and try again!");
            }
        }

    }
}
