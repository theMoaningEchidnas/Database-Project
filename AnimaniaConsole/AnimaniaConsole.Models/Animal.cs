namespace AnimaniaConsole.Models
{
    public class Animal
    {
        public Animal()
        {

        }

        public int Id { get; set; }
        public string AnimalName { get; set; }
        public int Age { get; set; }
        public virtual User UserId { get; set; }
        public virtual  AnimalType AnimalTypeId { get; set; }
        public virtual Breed BreedID { get; set; }


    }
}