using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimaniaConsole.Models
{

    public class User
    {
        public User()
        {
            this.Posts = new HashSet<Post>();
            this.Animals = new HashSet<Animal>();

        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        //[Index(IsUnique = true)]
        //[StringLength(12, MinimumLength = 6, ErrorMessage = "Invalid username! It must be between 6 and 12 characters")]
        //[RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Invalid username! It must contain letters and digits only")]
        public string UserName { get; set; }

        //[Required]
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$", ErrorMessage = "Invalid password! It must contain at least one digit, one lowercase letter and one uppercase letter")]
        public string Password { get; set; }

        //[RegularExpression(@"^([a-zA-Z\-]+$", ErrorMessage = "Invalid FirstName! It must contain only letters")]
        //[StringLength(12, MinimumLength = 1, ErrorMessage = "Invalid FirstName! It must be between 1 and 12 characters")]
        public string FirstName { get; set; }

        //[RegularExpression(@"^([a-zA-Z\-]+$", ErrorMessage = "Invalid FirstName! It must contain only letters")]
        //[StringLength(12, MinimumLength = 1, ErrorMessage = "Invalid LastName! It must be between 1 and 12 characters")]
        public string LastName { get; set; }

        public string Tel { get; set; }
        public string Skype { get; set; }
        public string FaceBook { get; set; }

        //[Required]
        //[EmailAddress]
        //[Index(IsUnique = true)]
        //[StringLength(100, MinimumLength = 3, ErrorMessage = "Invalid Email! It must be between 1 and 100 characters")]
        public string Email { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Animal> Animals { get; set; }

    }
}