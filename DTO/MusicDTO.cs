using System.ComponentModel.DataAnnotations;

namespace RepositoryPattern_MYSQL_Youtube.DTO
{
    public class MusicDTO
    {
        // To keep it simple, we are going to use a DTO object like the base model
        // Valication attribues is useful

        public string Id { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Artist { get; set; }
        public int Rate { get; set; }

    }
}