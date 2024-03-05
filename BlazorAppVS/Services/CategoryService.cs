using BlazorAppVS.Models;
using System.Text.Json;

namespace BlazorAppVS.Services;
public class CategoryService : ICategoryService
{
    private readonly HttpClient client;
    private readonly JsonSerializerOptions options;

    public CategoryService(HttpClient client)
    {
        this.client = client;
        this.options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }
    public async Task<List<Category>?> Get()
    {
        var response = await client.GetAsync("https://api.escuelajs.co/api/v1/categories");
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }

        return JsonSerializer.Deserialize<List<Category>>(content, options);
    }
}

public interface ICategoryService
{
    Task<List<Category>?> Get();
}
