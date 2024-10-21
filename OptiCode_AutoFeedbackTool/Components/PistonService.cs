using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class PistonService
{
    private readonly HttpClient _httpClient;

    public PistonService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public class Runtime
    {
        public string Language { get; set; }
        public string Version { get; set; }
        public List<string> Aliases { get; set; }
    }

    public async Task<string> ExecuteCodeAsync(string language, string sourceCode)
    {
        var runtimesResponse = await _httpClient.GetAsync("https://emkc.org/api/v2/piston/runtimes");
        if (!runtimesResponse.IsSuccessStatusCode)
        {
            var errorContent = await runtimesResponse.Content.ReadAsStringAsync();
            return $"Error retrieving runtimes: {runtimesResponse.StatusCode}, {errorContent}";
        }

        var runtimesContent = await runtimesResponse.Content.ReadAsStringAsync();
        var runtimes = JsonConvert.DeserializeObject<List<Runtime>>(runtimesContent);

        var runtime = runtimes
            .FirstOrDefault(r => r.Language.Equals(language, StringComparison.OrdinalIgnoreCase));

        if (runtime == null)
        {
            return $"Error: Language '{language}' is not supported.";
        }

        var version = runtime.Version;

        if (string.IsNullOrEmpty(version))
        {
            return $"Error: Language '{language}' has an unavailable version.";
        }

        var requestPayload = new
        {
            language = language,
            version = version,
            files = new[]
            {
            new
            {
                content = sourceCode
            }
        }
        };

        var jsonContent = new StringContent(JsonConvert.SerializeObject(requestPayload), Encoding.UTF8, "application/json");

        try
        {
            var response = await _httpClient.PostAsync("https://emkc.org/api/v2/piston/execute", jsonContent);
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return $"Error: {response.StatusCode}, {response.ReasonPhrase}, {errorContent}";
            }

            return await response.Content.ReadAsStringAsync();
        }
        catch (HttpRequestException ex)
        {
            return $"Request error: {ex.Message}";
        }
    }



}
