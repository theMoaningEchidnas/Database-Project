using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimaniaConsole.Models
{
    public class AnimalType
    {
        public AnimalType()
        {
            this.BreedTypes = new HashSet<BreedType>();
        }

        public byte Id { get; set; }
        public string AnimalTypeName { get; set; }

        public virtual ICollection<BreedType> BreedTypes { get; set; }
    }
}
