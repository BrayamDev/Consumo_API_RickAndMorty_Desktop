using Newtonsoft.Json;
using RickAndMortyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RickAndMortyAPI.Controllers
{
    public class CharacterController
    {
        private HttpClient _httpClient;

        public CharacterController()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Characters> getAllCharacters() 
        {
            try
            {
                Characters characters = new Characters();
                HttpResponseMessage response = await
                    _httpClient.GetAsync("https://rickandmortyapi.com/api/character");

                response.EnsureSuccessStatusCode();

                string responseJson = await response.Content.ReadAsStringAsync();

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
