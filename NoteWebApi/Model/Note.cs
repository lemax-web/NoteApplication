using System.ComponentModel.DataAnnotations;

namespace NoteWebApi.Model
{
    public class Note
    {
        [Key]
        public string Id { get; set; }
        
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
