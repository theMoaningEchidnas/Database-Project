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

        public PostService(IAnimaniaConsoleContext context)
        {
            this.context = context;
        }

        public IEnumerable<PostModel> GetAll()
        {
            var posts = this.context.Posts.ProjectTo<PostModel>();
            return posts;
        }

        public void CreatePost(CreatePostModel createPostModel)
        {
            var locationId = context.Locations.Any(x => x.LocationName == createPostModel.LocationName) ?
                context.Locations.Where(x => x.LocationName == createPostModel.LocationName).Select(x => x.Id).Single() :
            throw new ArgumentException("Such Location does not exist");
            
            var animalTypeId = context.AnimalTypes.Any(x => x.AnimalTypeName == createPostModel.AnimalTypeName) ?
                context.AnimalTypes.Where(x => x.AnimalTypeName == createPostModel.AnimalTypeName).Select(x => x.Id).Single() :
                throw new ArgumentNullException("Such type of Animal does not exist");
            
            var breedTypeId = context.BreedTypes.Any(x => x.BreedTypeName == createPostModel.BreedTypeName) ?
                context.BreedTypes.Where(x => x.BreedTypeName == createPostModel.BreedTypeName).Select(x => x.Id).Single() :
                throw new ArgumentNullException("Such type of Breed does not exist");

            //TODO: add the ID of the logged user
            var userId = 1;
               
            var animal = new Animal
            {
                AnimalName = createPostModel.AnimalName,
                Birthday = DateTime.Parse(createPostModel.Birthday.ToString()),
                AnimalTypeId = byte.Parse(animalTypeId.ToString()),
                BreedTypeId = int.Parse(breedTypeId.ToString()),
                LocationId = int.Parse(locationId.ToString()),
                UserId = userId
            };

            var post = new Post();

            var postToCreate = AutoMapper.Mapper.Map<Post>(createPostModel);
            postToCreate.Animal = animal;
            postToCreate.User = context.Users.Find(userId);
            

            this.context.Posts.Add(postToCreate);
            this.context.SaveChanges();
        }

    }
}
