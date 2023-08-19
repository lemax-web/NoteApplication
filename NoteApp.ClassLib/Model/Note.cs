using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.ClassLib.Model
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

        public Note(int id, string title, string description, int userId)
        {
            Id = id;
            Title = title;
            Description = description;
            UserId = userId;
        }
    }
}
