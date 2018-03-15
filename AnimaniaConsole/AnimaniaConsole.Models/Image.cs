namespace AnimaniaConsole.Models
{
    public class Image
    {
        public Image()
        {
         
        }

        public int Id { get; set; }
        public byte[] ImageFile { get; set; }
        public string ImageFileName { get; set; }

        public virtual int PostId { get; set; }

    }
}