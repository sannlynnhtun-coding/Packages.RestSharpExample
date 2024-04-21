using RestSharp;

Console.WriteLine("Hello, World!");

RestClientExample restClientExample = new RestClientExample();
await restClientExample.Run();

Console.ReadLine();

public class RestClientExample
{
    // https://jsonplaceholder.typicode.com/ => domain url
    private readonly RestClient client = new RestClient(new Uri("https://jsonplaceholder.typicode.com/"));
    private readonly string _postEndpoint = "posts";

    public async Task Run()
    {
        await List();
        await Create(1, "test title", "test body");

        await Edit(1);
        await Edit(100);
        await Edit(102);

        await Update(100, 2, "test title 2", "test body 2");
        await Patch(100, 3, "test title 3", "test body 3");
        await Delete(100);
    }

    private async Task List()
    {
        RestRequest request = new RestRequest(_postEndpoint, Method.Get);
        var response = await client.ExecuteAsync(request);
        if (response.IsSuccessStatusCode)
        {
            string jsonStr = response.Content!;
            Console.WriteLine(jsonStr);
        }
    }

    private async Task Edit(int id)
    {
        RestRequest request = new RestRequest($"{_postEndpoint}/{id}", Method.Get);
        var response = await client.ExecuteAsync(request);
        if (response.IsSuccessStatusCode)
        {
            string jsonStr = response.Content!;
            Console.WriteLine(jsonStr);
        }
        else
        {
            string jsonStr = response.Content!;
            Console.WriteLine(jsonStr);
        }
    }

    private async Task Create(int userId, string title, string body)
    {
        var item = new PostDto
        {
            body = body,
            title = title,
            userId = userId
        };

        RestRequest request = new RestRequest(_postEndpoint, Method.Post);
        request.AddJsonBody(item);
        var response = await client.ExecuteAsync(request);
        if (response.IsSuccessStatusCode)
        {
            string jsonStr = response.Content!;
            Console.WriteLine(jsonStr);
        }
    }

    private async Task Update(int id, int userId, string title, string body)
    {
        var item = new PostDto
        {
            body = body,
            title = title,
            userId = userId
        };

        RestRequest request = new RestRequest($"{_postEndpoint}/{id}", Method.Put);
        request.AddJsonBody(item);
        var response = await client.ExecuteAsync(request);
        if (response.IsSuccessStatusCode)
        {
            string jsonStr = response.Content!;
            Console.WriteLine(jsonStr);
        }
        else
        {
            string jsonStr = response.Content!;
            Console.WriteLine(jsonStr);
        }
    }
    private async Task Patch(int id, int userId, string title, string body)
    {
        var item = new PostDto
        {
            body = body,
            title = title,
            userId = userId
        };

        RestRequest request = new RestRequest($"{_postEndpoint}/{id}", Method.Patch);
        request.AddJsonBody(item);
        var response = await client.ExecuteAsync(request);
        if (response.IsSuccessStatusCode)
        {
            string jsonStr = response.Content!;
            Console.WriteLine(jsonStr);
        }
        else
        {
            string jsonStr = response.Content!;
            Console.WriteLine(jsonStr);
        }
    }

    private async Task Delete(int id)
    {
        RestRequest request = new RestRequest($"{_postEndpoint}/{id}", Method.Delete);
        var response = await client.ExecuteAsync(request);
        if (response.IsSuccessStatusCode)
        {
            string jsonStr = response.Content!;
            Console.WriteLine(jsonStr);
        }
        else
        {
            string jsonStr = response.Content!;
            Console.WriteLine(jsonStr);
        }
    }
}

public class PostDto
{
    public int userId { get; set; }
    public int id { get; set; }
    public string title { get; set; }
    public string body { get; set; }
}
