using System;
using System.Collections.Generic;

namespace AnimaniaConsole.Models
{
    public class Post
    {
        public Post()
        {
            this.Images = new HashSet<Image>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostDate { get; set; }
        public decimal Price { get; set; }

        public bool Status { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
        public int AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Image> Images { get; set; }

    }
}
