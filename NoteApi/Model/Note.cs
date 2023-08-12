using System.ComponentModel.DataAnnotations;

namespace NoteApi.Model
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
