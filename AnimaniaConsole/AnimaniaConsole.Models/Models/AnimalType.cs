using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Invalid AnimalTypeName! It must be between 4 and 30 characters")]
        public string AnimalTypeName { get; set; }

        public virtual ICollection<BreedType> BreedTypes { get; set; }
    }
}
