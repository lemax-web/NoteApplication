using NoteApp.ClassLib.Model;
using System.Net.Http.Json;

namespace NoteApp.Services
{
    public class NoteService :INoteService
    {
        private readonly HttpClient _httpClient;
        public NoteService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public async Task<List<Note>> getUsers()
        {

            return await _httpClient.GetFromJsonAsync<List<Note>>("api/Note");
        }
    }
}
