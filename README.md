# FGuiro.APICalls
API Calls avec HttpClientFactory
# Appel d'une API distante avec HttpClientFactory
Lorsque vous créez une application qui consomme une API distante, vous avez besoin d'une manière efficace pour envoyer des requêtes HTTP et recevoir des réponses HTTP. La classe standard dans .NET pour cette tâche est `HttpClient`.

Cependant, créer plusieurs instances d'`HttpClient` peut poser des problèmes de gestion de la durée de vie et de réutilisation des connexions. C'est là que `HttpClientFactory` intervient.

## Installation de `HttpClientFactory`
Pour installer `HttpClientFactory`, vous devez ajouter le package NuGet ``` Microsoft.Extensions.Http ``` à votre projet.

```
Install-Package Microsoft.Extensions.Http
```

Une fois que vous avez ajouté le package à votre projet, vous pouvez utiliser HttpClientFactory dans votre code en l'enregistrant dans le conteneur d'injection de dépendances de votre application. Voici un exemple:

```
public void ConfigureServices(IServiceCollection services)
{
    services.AddHttpClient("JsonPlaceholderClient", client =>
    {
        client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
    });
    // ...

}
```

Vous pouvez ensuite injecter IHttpClientFactory dans vos classes pour créer des instances d'HttpClient. Par exemple:

```
 public class JsonPlaceholderService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public JsonPlaceholderService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
    public async Task<IEnumerable<Post>> GetPostsAsync()
    {
        // do some thing
    }
}
```

## utilisation
Dans votre code, vous pouvez récupérer une instance nommée d'HttpClient en utilisant la méthode ``IHttpClientFactory.CreateClient()`` et l'utiliser pour envoyer des requêtes HTTP.

```
public async Task<IEnumerable<Post>> GetPostsAsync()
{
    var response = await _httpClient.GetAsync("posts");
    response.EnsureSuccessStatusCode();
    var content = await response.Content.ReadAsStringAsync();
    return JsonSerializer.Deserialize<IEnumerable<Post>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
}
    
```

En utilisant `HttpClientFactory`, nous avons simplifié la gestion des instances d'`HttpClient` et créé une instance nommée `JsonPlaceholderClient` avec une configuration spécifique. Nous avons ensuite injecté cette instance dans notre `JsonPlaceholderService` et utilisé cette instance pour envoyer une requête GET à l'API `JSONPlaceholder`

En résumé, HttpClientFactory est une fonctionnalité importante pour créer et gérer des instances d'HttpClient avec une configuration spécifique. Cela peut améliorer la gestion de la durée de vie, la réutilisation des connexions et la facilité de configuration de votre code d'appel API.

Rendez-vous sur  [API Calls avec HttpClientFactory (linkedin)](https://www.linkedin.com/pulse/api-calls-avec-httpclientfactory-mouhamed-fadel-guiro) !
