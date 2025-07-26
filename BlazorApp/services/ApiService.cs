using System.Net.Http.Headers;

public class ApiService
   {
      

    public async Task<List<T>> GetItemsAsync<T>(string url)
    {
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
        };
        using var http = new HttpClient(handler);

        http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "ae8bad44-7348-11ee-b962-0242ac120002");
        var response = await http.GetFromJsonAsync<List<T>>(url);
        return response ?? new List<T>();
    }

       // Métodos para POST, PUT, DELETE, etc.
   }