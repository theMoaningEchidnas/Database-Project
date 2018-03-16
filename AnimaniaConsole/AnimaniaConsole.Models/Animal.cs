using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimaniaConsole.Models
{
    public class Animal
    {
        public Animal()
        {
            this.Images = new HashSet<Image>();
        }
        
        public int Id { get; set; }

        public int? PostId { get; set; } //there are animals that are not included in posts yet
        public virtual Post Post { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Please, more than 1 and less than 50 symbols")]
        public string AnimalName { get; set; }



        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:DD.MM.YYYY}")]
        public DateTime? Birthday { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("BreedType")]
        public int? BreedTypeID { get; set; }
        public virtual BreedType BreedType { get; set; }

        [ForeignKey("AnimalType")]
        public int AnimalTypeID { get; set; }
        public virtual AnimalType AnimalType { get; set; }


        [Required, ForeignKey("Location")]
        public int LocationID { get; set; }
        public virtual Location Location { get; set; }

        public virtual ICollection<Image> Images { get; set; }

    }
}