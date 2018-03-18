using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimaniaConsole.Models.Models
{
    public class Post
    {
        public Post()
        {
            //this.Images = new HashSet<Image>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //public int? UserId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Please, more than 10 and less than 50 symbols")]
        public string Title { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 20, ErrorMessage = "Please, more than 20 and less than 1000 symbols")]
        //[RegularExpression(@"^((?!([\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))))[\S\s])*$", ErrorMessage = "Please do not include an email address in your field description.")]
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:DD.MM.YYYY}")]
        public DateTime PostDate { get; set; }

        [Range(0, 100000, ErrorMessage = "Please, provide a price in range of 0 to 100,000")]
        public decimal Price { get; set; }

        //TODO: check whether we can provide default value here
        public bool Status { get; set; }

        public int AnimalId { get; set; }
        //[Required]
        public virtual Animal Animal { get; set; }

        //public virtual ICollection<Image> Images { get; set; }

    }
}
