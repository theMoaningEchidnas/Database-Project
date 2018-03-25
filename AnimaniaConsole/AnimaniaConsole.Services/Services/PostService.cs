using AnimaniaConsole.Data;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Models.Models;
using AnimaniaConsole.Services.Contracts;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimaniaConsole.Services.Services

{
    public class PostService : IPostService
    {
        private readonly IAnimaniaConsoleContext context;
        private readonly ILocationServices locationServices;
        private readonly IAnimalTypeServices animalTypeServices;
        private readonly IBreedTypeServices breedTypeServices;

        public PostService(IAnimaniaConsoleContext context, ILocationServices locationServices, IAnimalTypeServices animalTypeServices, IBreedTypeServices breedTypeServices)
        {
            this.context = context;
            this.locationServices = locationServices;
            this.animalTypeServices = animalTypeServices;
            this.breedTypeServices = breedTypeServices;
        }

        public IEnumerable<PostModel> GetAllPosts()
        {
            var posts = this.context.Posts.ProjectTo<PostModel>();
            return posts;
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

        public IEnumerable<PostModel> SearchPosts(string searchedText)
        {
            var posts = this.context.Posts.ProjectTo<PostModel>();
            var searchResult = posts.Where(x => x.Title.Contains(searchedText) || x.Description.Contains(searchedText)).ToList();

            return searchResult;
        }
    }
}
