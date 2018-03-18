using System.ComponentModel.DataAnnotations.Schema;

namespace AnimaniaConsole.Models.Models
{
    public class BreedType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string BreedTypeName { get; set; }

        [ForeignKey("AnimalType")]
        public byte AnimalTypeId { get; set; }
        public virtual AnimalType AnimalType { get; set; }

    }
}
