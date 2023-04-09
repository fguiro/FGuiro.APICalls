using System.Text.Json;

namespace FGuiro.APICalls
{
    public class JsonPlaceholderService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private const string _instanceName = "JsonPlaceholderClient";

        public JsonPlaceholderService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Post>> GetPostsAsync() 
        {
            using (var client = _httpClientFactory.CreateClient(_instanceName))
            {
                var response = await client.GetAsync("posts");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    var posts = JsonSerializer.Deserialize<List<Post>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    return posts;

                }
                else
                {
                    Console.WriteLine($"Failed to retrieve posts: {response.StatusCode}");

                    return null;
                }

            }
        }
    }

    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
