using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimaniaConsole.Models.Models
{
    public class AnimalType
    {
        public AnimalType()
        {
            this.BreedTypes = new HashSet<BreedType>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        public string AnimalTypeName { get; set; }

        public virtual ICollection<BreedType> BreedTypes { get; set; }
    }
}
