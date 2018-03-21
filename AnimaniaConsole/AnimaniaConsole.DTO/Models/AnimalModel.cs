using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimaniaConsole.DTO.Models
{
    public class AnimalModel
    {
            public string AnimalName { get; set; }
            public DateTime? Birthday { get; set; }
            public int UserId { get; set; }
            public int? BreedTypeId { get; set; }
            public byte AnimalTypeId { get; set; }
            public int LocationId { get; set; }
    }
}
