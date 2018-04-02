using AnimaniaConsole.Data;
using System;
using System.Linq;
using AnimaniaConsole.Services.Contracts;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using AnimaniaConsole.DTO.Models;
using AutoMapper;
using AnimaniaConsole.Models.Models;

namespace AnimaniaConsole.Services.Services
{
    public class BreedTypeServices : IBreedTypeServices
    {
        private readonly IAnimaniaConsoleContext context;
        private readonly IMapper mapper;

        public BreedTypeServices(IAnimaniaConsoleContext ctx, IMapper mapper)
        {
            this.context = ctx;
            this.mapper = mapper;
        }
        public int GetBreedTypeIdByBreedTypeName(string breedTypeName)
        {
            var breedTypeId = context.BreedTypes
                .Where(x => x.BreedTypeName == breedTypeName)
                .Select(x => x.Id)
                .SingleOrDefault();

            if (breedTypeId == 0)
            {
                throw new ArgumentException("Such type of Breed does not exist");
            }
            return breedTypeId;

        }

        public void LoadBreedsFromJSON(string path, string animal)
        {
            var animalID = context.AnimalTypes.SingleOrDefault(x => x.AnimalTypeName == animal);
            if (animalID == null)
            {
                throw new Exception("No animal type found.");
            }

            string breeds = File.ReadAllText(path);
            DogBreedsSchema animals = JsonConvert.DeserializeObject<DogBreedsSchema>(breeds);

            foreach (var breed in animals.Breeds)
            {
                CreateBreedModel newBreed = new CreateBreedModel();
                newBreed.AnimalTypeID = animalID.Id;
                newBreed.BreedTypeName = breed;

                var mappedBreed = mapper.Map<BreedType>(newBreed);
                context.BreedTypes.Add(mappedBreed);
            }

            try
            {
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Cannot insert duplicate key row in BreedTypes");
            }
        }

        private class DogBreedsSchema
        {
            [JsonProperty("dogs")]
            public List<string> Breeds { get; set; }
        }
    }
}
