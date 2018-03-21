using AnimaniaConsole.Models.Models;
using System;
using System.Collections.Generic;
using User = AnimaniaConsole.Data.Migrations.User;

namespace AnimaniaConsole.DTO.Models
{
    public class PostModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostDate { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Animal Animal { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}
