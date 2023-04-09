using FGuiro.APICalls;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
ConfigureServices(services);
var serviceProvider = services.BuildServiceProvider();

var myService = serviceProvider.GetService<JsonPlaceholderService>();

if (myService != null)
{
    var posts = await myService.GetPostsAsync();

    foreach (var post in posts)
    {
        Console.WriteLine($"ID: {post.Id}");
        Console.WriteLine($"Title: {post.Title}");
        Console.WriteLine($"Body: {post.Body}");
        Console.WriteLine();
    }
}
else
{
    Console.WriteLine("Failed to load MyService");
}

static void ConfigureServices(IServiceCollection services)
{
    //utilisation de httpClient sans config specifique )

    //services.AddHttpClient();

    // si on veut nommee l'instance de IHttpClient utiliser dans JsonPlaceholderService
    services.AddHttpClient("JsonPlaceholderClient", client =>
    {
        client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
    });

    services.AddTransient<JsonPlaceholderService>();
}
