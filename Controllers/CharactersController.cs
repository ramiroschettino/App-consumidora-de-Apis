using Newtonsoft.Json;
using RYMApi.Models;

namespace RYMApi.Controllers
{
    public class CharactersController
    {
        private HttpClient _client = new HttpClient();

        public CharactersController() 
        {
            _client = new HttpClient();
        }

        public async Task<Characters> GetAllCharacters() 
        {
            try
            {
                Characters characters = new Characters();
                HttpResponseMessage resp = await _client.GetAsync("https://rickandmortyapi.com/api/character");

                resp.EnsureSuccessStatusCode();

                string responseJson = await resp.Content.ReadAsStringAsync();

                characters = JsonConvert.DeserializeObject<Characters>(responseJson);

                return characters;
            }
            catch (Exception ex) 
            {
                return null;
            }
        }
    }
}
