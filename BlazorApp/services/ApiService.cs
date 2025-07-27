using System.Net.Http.Headers;

public class ApiService
{
    private readonly IConfiguration _config;
    private readonly string _url;
    private readonly string _token;
    public ApiService(IConfiguration config)
    {
        _config = config;
        _url = _config["ApiURL"] ?? "";
        _token = _config["ApiToken"] ?? "";
    }

    public async Task<List<T>> GetItemsAsync<T>()
    {
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
        };
        using var http = new HttpClient(handler);
        http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
        var response = await http.GetFromJsonAsync<List<T>>(_url);
        return response ?? new List<T>();
    }
   }