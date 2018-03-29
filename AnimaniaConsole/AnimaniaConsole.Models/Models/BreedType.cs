using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimaniaConsole.Models.Models
{
    public class BreedType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Invalid BreedName! It must be between 3 and 30 characters")]
        public string BreedTypeName { get; set; }

        [ForeignKey("AnimalType")]
        public byte AnimalTypeId { get; set; }
        public virtual AnimalType AnimalType { get; set; }

    }
}
