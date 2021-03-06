﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimaniaConsole.Models.Models
{
    public class Animal
    {
        public Animal()
        {
            this.Images = new HashSet<Image>();
        }
        [ForeignKey("Post")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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
        public int? BreedTypeId { get; set; }
        public virtual BreedType BreedType { get; set; }

        [ForeignKey("AnimalType")]
        public byte AnimalTypeId { get; set; }
        public virtual AnimalType AnimalType { get; set; }

        public int LocationId { get; set; }
        public virtual Location Location { get; set; }

        public virtual ICollection<Image> Images { get; set; }

    }
}