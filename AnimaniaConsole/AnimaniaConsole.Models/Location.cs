using System.Collections.Generic;

namespace AnimaniaConsole.Models
{
    public class Location
    {

        public Location()
        {
            this.Animals = new HashSet<Animal>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }

    }
}