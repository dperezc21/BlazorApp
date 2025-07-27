using System.Net.Http.Headers;

public class ApiService
   {
      private readonly IConfiguration _config;
    public ApiService(IConfiguration config)
    {
        _config = config;
    }

    public async Task<List<T>> GetItemsAsync<T>(string url)
    {
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
        };
        using var http = new HttpClient(handler);
        var token = _config["ApiToken"];
        http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await http.GetFromJsonAsync<List<T>>(url);
        return response ?? new List<T>();
    }

       // Métodos para POST, PUT, DELETE, etc.
   }