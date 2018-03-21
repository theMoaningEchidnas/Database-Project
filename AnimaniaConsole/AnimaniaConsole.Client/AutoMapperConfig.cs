using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimaniaConsole.DTO;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Models.Models;
using AutoMapper;

namespace Client
{
    public static class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<PostModel, Post>().ReverseMap();
                config.CreateMap<CreateUserModel, User>().ReverseMap();

                config.CreateMap<CreatePostModel, Post>().ReverseMap();
            });

        }


    }
}
