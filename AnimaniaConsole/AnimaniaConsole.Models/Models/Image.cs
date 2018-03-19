using System.ComponentModel.DataAnnotations.Schema;

namespace AnimaniaConsole.Models.Models
{
    public class Image
    {
        public Image()
        {
         
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public byte[] ImageFile { get; set; }
        public string ImageFileName { get; set; }

        public virtual int PostId { get; set; }

    }
}