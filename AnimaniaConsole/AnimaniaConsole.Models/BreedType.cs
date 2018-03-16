using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimaniaConsole.Models
{
    public class BreedType
    {
        public int ID { get; set; }
        public string BreedTypeName { get; set; }

        [ForeignKey("AnimalType")]
        public int AnimaltypeID { get; set; }
        public virtual AnimalType AnimalType { get; set; }

    }
}
