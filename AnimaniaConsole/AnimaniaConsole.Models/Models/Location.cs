using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimaniaConsole.Models.Models
{
    public class Location
    {

        public Location()
        {
            this.Animals = new HashSet<Animal>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Location Name should be between 3 and")]
        public string LocationName { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }

    }
}