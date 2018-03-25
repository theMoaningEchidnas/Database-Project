using System;

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
        public AnimalModel Animal { get; set; }
        
    }
}
