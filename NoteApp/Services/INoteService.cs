using NoteApp.ClassLib.Model;

namespace NoteApp.Services
{
    public interface INoteService
    {
        Task<List<Note>> getUsers();
    }
}
