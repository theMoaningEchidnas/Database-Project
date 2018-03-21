using AnimaniaConsole.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimaniaConsole.DTO.Models
{
    public class CreatePostModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostDate { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; }

        public string AnimalName { get; set; }
        public DateTime? Birthday { get; set; }
        public string BreedTypeName { get; set; }
        public string AnimalTypeName { get; set; }
        public string LocationName { get; set; }


    }
}
