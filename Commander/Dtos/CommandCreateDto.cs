using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos
{
    public class CommandCreateDto
    {
        // Id will be created by database, so it shouldn't be supplied
        // public int Id { get; set; }

        // Added annotations, so when there is a mistake in passing data to app, the error code says that user made an error, not app.
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public string Platform { get; set; }
    }
}
