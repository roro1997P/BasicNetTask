using Domain.Heroes;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Heroes
{
    public class FetchHeroesUseCase : IUseCase<object, IEnumerable<Hero>>
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _apiHash;

        public FetchHeroesUseCase(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["ApiKeys:MarvelApiKey"];
            _apiHash = configuration["ApiKeys:MarvelApiHash"];
        }

        public async Task<IEnumerable<Hero>> ExecuteAsync(object request)
        {
            var address = _httpClient.BaseAddress;

            var data = await _httpClient.GetFromJsonAsync<MarvelApiResponse>($"characters?ts=1000&apikey={_apiKey}&hash={_apiHash}");
            //var data = await _httpClient.GetFromJsonAsync<MarvelApiResponse>("characters?ts=1000&apikey=6b3354ea9743194b5c5a52dfe6041199&hash=dda869c964ba2cca412a99c4ce592bb6");

            var heroes = new List<Hero>();

            foreach (var result in data.Data.Results)
            {
                heroes.Add(new Hero(
                    result.Id, result.Name, result.Description,
                    new Thumbnail(result.Thumbnail.Path, result.Thumbnail.Extension),
                    result.ResourceURI
                ));
            }
            return heroes;
        }
    }

    public record MarvelApiResponse
    {
        public int Code { get; set; }
        public string Status { get; set; }
        public MarvelData Data { get; set; }
    }

    public record MarvelData
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
        public int Total { get; set; }
        public int Count { get; set; }
        public List<HeroDto> Results { get; set; }
    }

    public record HeroDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ThumbnailDto Thumbnail { get; set; }
        public string ResourceURI { get; set; }
    }

    public record ThumbnailDto
    {
        public string Path { get; set; }
        public string Extension { get; set; }
    }
}
